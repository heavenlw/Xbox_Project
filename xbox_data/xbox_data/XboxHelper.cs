﻿using System;
using System.Collections.Generic;

namespace xbox_data
{
    internal class XboxHelper
    {
        public XboxHelper()
        {
        }

        internal static void Start()
        {
            List<Keyword> k_list = new List<Keyword>();
            List<Seed> seed_list = new List<Seed>();
            MysqlHelper mysqlhelper = new MysqlHelper();
            k_list = mysqlhelper.GetKeywordList();
            seed_list = mysqlhelper.GetSeed();
            foreach (Keyword one_keyword in k_list)
            {
                Console.WriteLine("Searching keyword:    " + one_keyword.Word);
                foreach (Seed one_seed in seed_list)
                {
                    Console.WriteLine("          Searching Website:    " + one_seed.Name);
                    SearchHelper searchhelper = new SearchHelper();
                    List<Video> v_list = searchhelper.Search(one_keyword,one_seed);
                    string sql = "";
                    foreach (Video one_video in v_list)
                    {
                        sql += string.Format("insert into cache set c_url='{0}',c_title='{1}',k_id='{2}',r_id='{3}',c_thumb='{4}',c_time='{5}',flash='{6}',embed='{7}',iframe='{8}',course_id='{9}';\n\t",one_video.Link,one_video.Title,one_keyword.Id,one_seed.Id,one_video.Pic,one_video.Time,one_video.Flash,one_video.Embed,one_video.Iframe,one_keyword.Course_Id);
                    }
                    mysqlhelper.InsertSQL(sql);
                }
            }

        }
    }

   
}