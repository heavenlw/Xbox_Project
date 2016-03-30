using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace xbox_data
{
    internal class MysqlHelper
    {
        private String connStr = "server=awol.cvlp2mlfriyg.us-west-2.rds.amazonaws.com; uid=heavenlw;pwd=550804648;database=xbox_data;";

        internal List<Trans> GetText()
        {
            List<Trans> list = new List<Trans>();
              string sql = "select * from text";
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {

                conn.Open();
                // 创建一个适配器
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
            }
            // 关闭数据库连接.
            catch (Exception e)
            {

                Console.WriteLine(e.Message);


            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null)
            {
                foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
                {
                    //Keyword keyword = new Keyword();
                    string id = testRow["kid"].ToString();
                    string word = testRow["t_content"].ToString();
                    Trans t = new Trans();
                    t.Id = id;
                    t.Content = word;
                    list.Add(t);
                 
                }
            }
            return list;

        }
        string sql = "";
        internal void UpdateContent(Trans t)
        {
           sql += string.Format("update keyword set content='{0}' where id={1}; ", t.Content, t.Id);
             
           
        }

        //private String connStr = "server=localhost; uid=root;pwd=123456;database=xbox_data;";
        internal void Handle(List<Video> v_list)
        {
            
        }

        internal List<Keyword> GetKeywordList()
        {
            List<Keyword> seeds = new List<Keyword>();
            string selectSeeds_sql = "select * from keyword";
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {

                conn.Open();
                // 创建一个适配器
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectSeeds_sql, conn);
                // 创建DataSet，用于存储数据.
                testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
            }
            // 关闭数据库连接.
            catch (Exception e)
            {

                Console.WriteLine(e.Message);


            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null)
            {
                foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
                {
                    Keyword keyword = new Keyword();
                    string id = testRow["id"].ToString();
                    string word = testRow["k_word"].ToString();
                    keyword.Id = id;
                    keyword.Word = word;
                    keyword.Course_Id = testRow["course_id"].ToString();
                    seeds.Add (keyword);
                }
            }
            return seeds;
        }

        internal List<Seed> GetSeed()
        {
            List<Seed> seeds = new List<Seed>();
            string selectSeeds_sql = "select * from regex where status = 1";
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {

                conn.Open();
                // 创建一个适配器
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectSeeds_sql, conn);
                // 创建DataSet，用于存储数据.
                testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
            }
            // 关闭数据库连接.
            catch (Exception e)
            {

                Console.WriteLine(e.Message);


            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null)
            {
                foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
                {
                    Seed seed = new Seed();
                    string id = testRow["id"].ToString();
                    string url= testRow["v_url"].ToString();
                    string list = testRow["v_list"].ToString();
                    string time= testRow["v_time"].ToString();
                    string encoding = testRow["v_encoding"].ToString();
                    string title = testRow["v_title"].ToString();
                    string name = testRow["v_name"].ToString();
                    string link = testRow["v_link"].ToString();
                    string pic = testRow["v_thumb"].ToString();
                    ///string time = testRow["v_time"].ToString();
                    seed.Id = id;
                    seed.Url = url;
                    seed.List = list;
                    seed.Time = time;
                    seed.Title = title;
                    seed.Name = name;
                    seed.Link = link;
                    seed.Pic = pic;
                    //seed.Time = time;
                    seeds.Add(seed);
                }
            }
            return seeds;
        }

        public void InsertSQL(string sql)
        {
            string error = null;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                error = Transaction(conn, sql);
                conn.Close();
                //Console.WriteLine(url +news.Title+"保存成功");
                //log.Error(url + news.Title + "保存成功");
            }
            catch (Exception e)
            {
                error = e.Message;

                Console.WriteLine(error);
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        private string Transaction(MySqlConnection conn, string sql)
        {
            string errorStr = null;
            MySqlTransaction t = conn.BeginTransaction();
            bool isTranSucceed = true;
            try
            {
                HandleSql(conn, t, sql);
                t.Commit();
            }
            catch (Exception e)
            {
                t.Rollback();
                isTranSucceed = false;
                errorStr = e.Message;
                Console.WriteLine(e.Message);

            }
            return errorStr;
        }
        private void HandleSql(MySqlConnection conn, MySqlTransaction t, string sql)
        {
            // 创建一个 Command.
            MySqlCommand insertCommand = conn.CreateCommand();

            // 定义需要执行的SQL语句.
            insertCommand.CommandText = sql;
            // 注意： 只有加了这一句， 才能事务处理！！！
            //insertCommand.Transaction = t;
            int insertRowCount = insertCommand.ExecuteNonQuery();
        }
    }
}