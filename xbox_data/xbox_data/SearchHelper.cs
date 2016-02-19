using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace xbox_data
{
    internal class SearchHelper
    {
        public SearchHelper()
        {
        }

     

        internal List<Video> Search(Keyword one_keyword,Seed seed)
        {
            List<Video> video_list = new List<Video>();
            for (int i = 1; i <= 20; i++)
            {
                string url = string.Format(seed.Url, one_keyword.Word,i);
                // List<string> url_list = new List<string>();
                Uri uri = new Uri(url);


                HttpWebRequest webRequest1 = (HttpWebRequest)WebRequest.Create(uri); //获取servertime和 nonce
                                                                                     // webRequest1.CookieContainer = cc;
                webRequest1.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                //webRequest1.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                webRequest1.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-CN;q=0.2");
                webRequest1.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.97 Safari/537.36";
                //webRequest1.Referer = "http://weibo.com/";
               // webRequest1.Host = "www.soku.com";
                //webRequest1.Headers.Add("cookie", "JobsD    B.IsAssignedDefaultSummaryMode2=0; s_vnum=1456676225302%26vn%3D2; ASP.NET_SessionId=gb5yn5w0nwmzs0ourszh4sq1; OAID=2bc0aa9a24db37d330b29d21b22888e2; RecentSearch=%7B%22JobFunction%22%3A%5B%22131%22%5D%7D; JLP=True; HideShowBulletInfo=%7B%22DontShowPromoAgain%22%3Afalse%2C%22DefaultShow%22%3Anull%2C%22PromoBubbleShowTimes%22%3A2%7D; s_invisit=true; s_cc=true; s_sq=%5B%5BB%5D%5D; s_vi=[CS]v1|2B55C840052AB03D-60000301E03ED0BB[CE]; __utma=244694174.472673730.1454084226.1454084226.1454135435.2; __utmb=244694174.23.10.1454135435; __utmc=244694174; __utmz=244694174.1454084226.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); JobsDB.IsCookieSupported=true; __utma=21133218.1113723173.1454084226.1454084226.1454135435.2; __utmb=21133218.71.9.1454137671031; __utmc=21133218; __utmz=21133218.1454084226.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)");
                //webRequest1.Headers.Add("DNT", "1");
                HttpWebResponse response1 = (HttpWebResponse)webRequest1.GetResponse();

                StreamReader sr1 = new StreamReader(response1.GetResponseStream(), UTF8Encoding.UTF8, true);
                String res = null;

                if (response1.ContentEncoding == "gzip")
                {
                    // res = sr1.ReadToEnd();
                    //StreamReader sr1 = new StreamReader(response1.GetResponseStream(), Encoding.UTF8);
                    //是否要解压缩stream？
                    res = GetResponseByZipStream(response1);
                    //Console.WriteLine(res);
                }
                else
                {
                    while (!sr1.EndOfStream)
                    {
                        res = sr1.ReadToEnd();

                    }

                }
                if (res != null && res.Length > 200)
                {
                    MatchCollection matches = Regex.Matches(res,seed.List, RegexOptions.Singleline);

                    foreach (Match mac in matches)
                    {
                        Video video = new Video();
                        string title = Regex.Match(mac.ToString(), seed.Title, RegexOptions.Singleline).Groups[1].ToString();
                        string link = Regex.Match(mac.ToString(), seed.Link, RegexOptions.Singleline).Groups[1].ToString();
                        string pic_url = Regex.Match(mac.ToString(), seed.Pic, RegexOptions.Singleline).Groups[1].ToString();
                        string time = Regex.Match(mac.ToString(), seed.Time, RegexOptions.Singleline).Groups[1].ToString();
                        video.Title = title;
                        link = CleanTheLink(link);
                        video.Link = link;
                        video.Time = time;
                        video.Pic = pic_url;
                        Console.WriteLine(title);
                        video_list.Add(video);
                    }

                }
            }
            return video_list;
        }

        private string CleanTheLink(string link)
        {
            return Regex.Match(link, "http.*?.html", RegexOptions.Singleline).ToString().Trim();
        }

        private string GetResponseByZipStream(HttpWebResponse response1)
        {
            GZipStream g = new GZipStream(response1.GetResponseStream(), CompressionMode.Decompress);
            StreamReader test = new StreamReader(g);
            return test.ReadToEnd();
        }
    }
}