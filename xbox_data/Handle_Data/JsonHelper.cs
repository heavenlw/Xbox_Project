using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace Handle_Data
{
    internal class JsonHelper
    {
        public JsonHelper()
        {
        }
        
        internal void HandleJson()
        {
           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<string> handle = new List<string>();

                // MysqlHelper mysqlhelper = new MysqlHelper();
                foreach (string file in openFileDialog1.FileNames)
                {
                    List<Question> question_list = new List<Question>();

                    try
                    {
                        Console.WriteLine(file);
                        //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(file);
                        string text = System.IO.File.ReadAllText(file);
                        JObject jobject = (JObject)JsonConvert.DeserializeObject(text);
                        JArray resultArray = (JArray)JsonConvert.DeserializeObject(jobject["list"].ToString());
                        var course = JsonConvert.DeserializeObject(jobject["courseSectionID"].ToString());
                        var pre_list = JsonConvert.DeserializeObject<List<Question>>(resultArray.ToString());


                        question_list.AddRange(pre_list);





                        MysqlHelper mysqlhelper = new MysqlHelper();
                        foreach (Question question in question_list)
                        {
                            question.content = Exp(question.content);
                            question.answerExplain = Exp(question.answerExplain);
                            string sql = string.Format("insert into question set questionID='{0}',questionNo='{1}',content='{2}',questionType='{3}',rightAnswer='{4}',answerExplain='{5}',difficulty='{6}',rightRate='{7}',isCollect='{8}',isOut='{9}',hot='{10}',courseSectionID='{11}'", question.questionID, question.questionNo, question.content, question.questionType, question.rightAnswer, question.answerExplain, question.difficulty, question.rightRate, question.isCollect, question.isOut, question.hot, course);
                            mysqlhelper.Insert(sql);
                        }
                    }
                    catch (Exception t)
                    {
                        Console.WriteLine(t.Message);

                    }
                    Console.WriteLine("Finish " + file);
                }
              
            }
            //MysqlHelper mysqlhelper = new MysqlHelper();
            //foreach (Question question in question_list)
            //{
            //    question.content = Exp(question.content);
            //    question.answerExplain = Exp(question.answerExplain);
            //    string sql = string.Format("insert into question set questionID='{0}',questionNo='{1}',content='{2}',questionType='{3}',rightAnswer='{4}',answerExplain='{5}',difficulty='{6}',rightRate='{7}',isCollect='{8}',isOut='{9}',hot='{10}'", question.questionID, question.questionNo, question.content, question.questionType, question.rightAnswer, question.answerExplain, question.difficulty, question.rightRate, question.isCollect, question.isOut, question.hot);
            //   // mysqlhelper.Insert(sql);
            //}
           
        }

        private List<Question> GetList(string file)
        {
            string error = "1";
            while (error == "1")
            {
                try
                {
                    //Thread.Sleep(2000);
                    Console.WriteLine(file);
                    //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(file);
                    string text = System.IO.File.ReadAllText(file);
                    JObject jobject = (JObject)JsonConvert.DeserializeObject(text);
                    JArray resultArray = (JArray)JsonConvert.DeserializeObject(jobject["list"].ToString());
                    return JsonConvert.DeserializeObject<List<Question>>(resultArray.ToString());

                }

                catch (Exception t)
                {
                    Console.WriteLine(t.Message);
                    error = "2";
                }
            }
            return null;
        }

        private string Exp(string content)
        {
            return Regex.Replace(content, "'", "\\'", RegexOptions.Singleline);
        }
    }
}