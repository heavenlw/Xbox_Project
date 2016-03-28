using MySql.Data.MySqlClient;
using System;

namespace Handle_Data
{
    internal class MysqlHelper
    {
       // private String connStr = "server=awol.cvlp2mlfriyg.us-west-2.rds.amazonaws.com; uid=heavenlw;pwd=550804648;database=xbox_data;";
        private string connStr = "server=localhost;uid=root;pwd=123456;database=xbox_data";
        public MysqlHelper()
        {
        }

        internal void Insert(string sql)
        {
            string error = null;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                error = Transaction(conn, sql);
                conn.Close();
           
            }
            catch (Exception e)
            {
                error = e.Message;

                Console.WriteLine(error);
              
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