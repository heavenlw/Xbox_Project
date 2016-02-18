using System;
using System.Text.RegularExpressions;
using WebHelper;

namespace xbox_detail
{
    internal class HandleHelper
    {
        internal void Handle(Video one_video, Seed seed)
        {
            if(one_video.Url!=null)
            {
                try
                {
                    string html = "";
                    Uri uri = new Uri(one_video.Url);
                    WebHandler webHandler = new WebHandler();
                    html = webHandler.GetResponseStr(uri, seed.Encoding);
                    if (html.Length > 200)
                    {
                        string title = Regex.Match(html, seed.Title_Reg, RegexOptions.Singleline).ToString() ;
                        
                    }
                   

                }
                catch (Exception)
                {
                    Console.WriteLine("Something worry with HandleHelper GetDetail function");
                }
            }
        }
    }
}