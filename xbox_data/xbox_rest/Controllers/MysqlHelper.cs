using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace xbox_rest.Controllers
{
    internal class MysqlHelper
    {
        private static string connStr_local = System.Configuration.ConfigurationManager.AppSettings["Conn2"];
        public MysqlHelper()
        {
        }


        internal List<Question> getQuestion(string id)
        {
            List<Question> question_list = new List<Question>();
            string sql = string.Format("select * from question where courseSectionID='{0}' and questionType=0 ORDER BY RAND() limit 5", id);
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
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
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                conn.Close();   
                Console.WriteLine(e.Message);
                return question_list;
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null)
            {
                foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
                {
                    Question question = new Question();
                    string content = testRow["content"].ToString();
                    question.questionID = testRow["questionID"].ToString();
                    question.difficulty = testRow["difficulty"].ToString();
                    question.content = content;
                    question.questionType = testRow["questionType"].ToString();
                    question.rightAnswer = testRow["rightAnswer"].ToString();
                    question.answerExplain = testRow["answerExplain"].ToString();
                    question_list.Add(question);

                }
            }
            return question_list;
        }

        internal string UpdateChapter(string id, string chapter)
        {
            chapter = DateTime.Now.ToShortDateString()+":" + chapter;
            string sql = string.Format("update user set u_chapter='{0}',last_update='{2}' where id ='{1}'", chapter,id,DateTime.Now);
            string error = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr_local);
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                DataSet testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
                return "success";
            }
            catch (Exception t)
            {
                return t.Message;
            }
            finally
            {
                conn.Close();
            }

        }

        internal string UpdateCurrentLevel(User user)
        {
            string sql = string.Format("update user set u_course_now={0} where id ='{1}'", user.CurrentlevelId, user.Id);
            string error = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr_local);
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                DataSet testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
                return "success";
            }
            catch (Exception t)
            {
                return t.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        internal void InsertGoal(User user)
        {
            string sql = string.Format("update user set  where id ='{1}'", user.Power, user.Id);
            string error = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr_local);
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                DataSet testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
               // return "success";
            }
            catch (Exception t)
            {
                //return t.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public Question randomById(string id)
        {
            Question question = new Question();
            string sql = string.Format("select * from question where courseSectionID='{0}' and questionType=2 ORDER BY RAND() limit 1", id);
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
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
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                conn.Close();
                Console.WriteLine(e.Message);
                return question;
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null)
            {
                foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
                {
                    //Question question = new Question();
                    string content = testRow["content"].ToString();
                    question.questionID = testRow["questionID"].ToString();
                    question.difficulty = testRow["difficulty"].ToString();
                    question.content = content;
                    question.questionType = testRow["questionType"].ToString();
                    question.rightAnswer = testRow["rightAnswer"].ToString();
                    question.answerExplain = testRow["answerExplain"].ToString();
                   

                }
            }
            return question;
        }

        public Explain GetExplainDetail(string id)
        {
            string sql = string.Format("select * from keyword k, cache c where k.course_id ={0} and k.id= c.k_id limit 3", id);
            Explain explain = new Explain();
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
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
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                conn.Close();
                Console.WriteLine(e.Message);
                return explain;
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null)
            {
                foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
                {
                    explain.word = testRow["k_word"].ToString();
                    explain.course_id = testRow["course_id"].ToString();
                    explain.content = testRow["content"].ToString();
                    Video video = new Video();
                    video.url = testRow["c_url"].ToString();
                    video.title = testRow["c_title"].ToString();
                    video.pic = testRow["c_thumb"].ToString();
                    video.time = testRow["c_time"].ToString();
                    video.flash = testRow["flash"].ToString();
                    video.embed = testRow["embed"].ToString();
                    video.iframe = testRow["iframe"].ToString();
                    
                    explain.video_list.Add(video);

                }
            }
            return explain;



        }

        internal void CreatUser(ref User user)
        {
            string sql = string.Format("insert into user set u_name='{0}',u_password='{1}',u_email='{2}',u_grade='{3}',u_firstname='{4}',u_lastname='{5}',u_gender='{6}',u_age='{7}'",user.Name,user.Password,user.Email,user.Grade,user.FirstName,user.LastName,user.Gender,user.Age);
            string error = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr_local);
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                DataSet testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
                user.Status = "success";

            }
            catch (Exception t)
            {
                user.Status = t.Message;

            }
            finally
            {
                conn.Close();
            }

        }

        internal bool SearchName(string name)
        {
            string sql = string.Format("select * from user where u_name='{0}'", name);
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
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
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                Console.WriteLine(e.Message);
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null && testDataSet.Tables["result_data"].Rows.Count > 0)
            {

                return true;

            }
            else
            {
                return false;
            }

        }

        public User CheckStatus(User user)
        {
            string sql = string.Format("select * from user where id = '{0}'", user.Id);
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
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
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                Console.WriteLine(e.Message);
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null && testDataSet.Tables["result_data"].Rows.Count > 0)
            {
                    user.Name = testDataSet.Tables["result_data"].Rows[0]["u_name"].ToString();
                    user.Status = "Success";
                    user.Id = testDataSet.Tables["result_data"].Rows[0]["id"].ToString();
                    user.CourseInfo = GetCourseList(testDataSet.Tables["result_data"].Rows[0]["u_courseId"].ToString(),user.Id);
                    user.Power = testDataSet.Tables["result_data"].Rows[0]["u_power"].ToString();
                    user.u_Chapter = testDataSet.Tables["result_data"].Rows[0]["u_chapter"].ToString();
                    user.last_update = testDataSet.Tables["result_data"].Rows[0]["last_update"].ToString();
                return user;
              
            }
            else
            {
                try
                {
                    user.Status = "No this User";
                    return user;
                }
                catch (Exception t)
                {
                    user.Status = "System Error";
                    return user;
                }
            }
        }

        internal string UpdatePower(User user)
       {
            
            string sql = string.Format("update user set u_power=u_power+{0},u_courseid=concat(u_courseid,+'{3};') where id ='{1}'", user.Power, user.Id,user.CourseNow,user.CourseNow+","+user.MasterCourse);
            string error = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr_local);
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                DataSet testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
                return "success";
            }
            catch (Exception t)
            {
                return t.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public User SearchUser(User user)
        {
            string sql = string.Format("select * from user u,keyword k where u.u_name = '{0}' and k.course_id = u.u_course_now", user.Name);
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
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
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                Console.WriteLine(e.Message);
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null && testDataSet.Tables["result_data"].Rows.Count > 0)
            {
                user.Id = testDataSet.Tables["result_data"].Rows[0]["id"].ToString();
                if (testDataSet.Tables["result_data"].Rows[0]["u_password"].ToString() == user.Password)
                {
                    user.Status = "Success";
                    user.Grade= testDataSet.Tables["result_data"].Rows[0]["u_grade"].ToString();
                    user.Id = testDataSet.Tables["result_data"].Rows[0]["id"].ToString();
                    user.CourseInfo = GetCourseList(testDataSet.Tables["result_data"].Rows[0]["u_courseId"].ToString(),user.Id);
                    user.Power = testDataSet.Tables["result_data"].Rows[0]["u_power"].ToString();
                    user.CourseNow =int.Parse(testDataSet.Tables["result_data"].Rows[0]["u_course_now"].ToString());
                    user.CourseNowName = testDataSet.Tables["result_data"].Rows[0]["k_word"].ToString();
                    return user;
                }
                else
                {

                    //updateLoginTime(user);
                    user.Status = "Password Error";
                    return user;
                }
            }
            else
            {
                try
                {
                    user.Status = "No this User";
                    return user;
                }
                catch (Exception t)
                {
                    user.Status = "System Error";
                    return user;
                }
            }
        }

        private List<CourseInfo> GetCourseList(string courseList,string user_id)
        {
            List<CourseInfo> list = new List<CourseInfo>();
            //SeedHelper seed = new SeedHelper();
            // var seed_list = seed.GetSeed();
          
            string[] courses = courseList.Split(';');
            int t = 0;
            if (courses.Length > 0)
            {
                foreach (string course in courses)
                {
                    CourseInfo courseinfo = new CourseInfo();
                    courseinfo.Id = Regex.Match(course, "(.*?),").Groups[1].ToString().Trim();
                    courseinfo.Degree = Regex.Match(course, ",(.*)").Groups[1].ToString().Trim();
                    var find_c = list.Find(CourseInfo => CourseInfo.Id == courseinfo.Id);
                    if (find_c != null)
                    {

                        list.Find(CourseInfo => CourseInfo.Id == courseinfo.Id).Degree =(int.Parse(find_c.Degree)+int.Parse(courseinfo.Degree)).ToString();
                        t = 1;
                    }
                    else
                    {
                        if (courseinfo.Id != "")
                        {
                            list.Add(courseinfo);
                        }
                    }
                }
                if (t == 1)
                {
                    UpdateCourseList(list,user_id);
                }
            }



            return list;
        }

        private void UpdateCourseList(List<CourseInfo> list, string user_id)
        {
            string course_list = "";
            foreach (CourseInfo c in list)
            {
                    course_list += (c.Id + "," + c.Degree + ";");
            }
            string sql = string.Format("update user set u_courseid = '{0}' where id ='{1}'",course_list,user_id);
            string error = null;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr_local);
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                DataSet testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
                // return "success";
            }
            catch (Exception t)
            {
                //return t.Message;
            }
            finally
            {
                conn.Close();
            }


        }

        internal List<Question> SelectExp(string sql)
        {
           // List<Question> question_list = new List<Question>();
            List<Question> question_list = new List<Question>();
           
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
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
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                conn.Close();
                Console.WriteLine(e.Message);
                return question_list;
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null)
            {
                foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
                {
                    Question question = new Question();
                    //int id = Convert.ToInt32(testRow["questionID"].ToString());
                    string content = testRow["content"].ToString();
                    question.questionID = testRow["questionID"].ToString();
                    question.content = content;
                    question.answerExplain = testRow["answerExplain"].ToString();
                    question_list.Add(question);

                }
            }
            return question_list;
        }

        internal List<Question> random()
        {
            List<Question> question_list = new List<Question>();
            string sql = string.Format("SELECT *FROM question AS t1 JOIN(SELECT ROUND(RAND() * ((SELECT MAX(id) FROM question) - (SELECT MIN(id) FROM question)) + (SELECT MIN(id) FROM question)) AS id) AS t2 WHERE t1.id >= t2.id ORDER BY t1.id LIMIT 5; ");
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
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
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                conn.Close();
                Console.WriteLine(e.Message);
                return question_list;
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null)
            {
                foreach (DataRow testRow in testDataSet.Tables["result_data"].Rows)
                {
                    Question question = new Question();
                    //int id = Convert.ToInt32(testRow["questionID"].ToString());
                    string content = testRow["content"].ToString();
                    question.questionID = testRow["questionID"].ToString();
                    question.content = content;
                    question.questionType = testRow["questionType"].ToString();
                    question.rightAnswer = testRow["rightAnswer"].ToString();
                    question.answerExplain = testRow["answerExplain"].ToString();
                    question.difficulty = testRow["difficulty"].ToString();
                    question_list.Add(question);

                }
            }
            return question_list;
        }
    }
}