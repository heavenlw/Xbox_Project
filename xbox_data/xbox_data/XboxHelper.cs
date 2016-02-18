using System;
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
            MysqlHelper mysqlhelper = new MysqlHelper();
            k_list = mysqlhelper.GetKeywordList();
            Keyword key = new Keyword();
            key.Word = "一元二次函数";
            k_list.Add(key);
            foreach (Keyword one_keyword in k_list)
            {
                SearchHelper searchhelper = new SearchHelper();
                List<Video> v_list=searchhelper.Search(one_keyword);
                string sql = "";
                foreach (Video one_video in v_list)
                {
                    sql += "insert into ";

                    
                }
                mysqlhelper.InsertSQL(sql);
            }

        }
    }

   
}