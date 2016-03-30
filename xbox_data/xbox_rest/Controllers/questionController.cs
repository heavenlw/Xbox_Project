using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace xbox_rest.Controllers
{
    public class questionController : ApiController
    {

        [HttpGet]
        public IHttpActionResult qslist(string id)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            return Ok(mysqlhelper.getQuestion(id));
        }

        [HttpGet]
        public IHttpActionResult random()
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            return Ok(mysqlhelper.random());
        }
        [HttpGet]
        public IHttpActionResult Explain(string qno)
        {
            string[] string_list = qno.Split(';');
            string pre_sql = "";
            for (int i = 0; i < string_list.Count(); i++)
            {
                if (i != string_list.Count()-1)
                {
                    pre_sql += "questionID=" + string_list[i] + " or ";

                }
                else
                {
                    pre_sql += " questionID=" + string_list[i];
                }
            }
        string sql = string.Format("select id,content,answerExplain from question where {0}",pre_sql);
            MysqlHelper mysqlhelper = new MysqlHelper();
            return Ok(mysqlhelper.SelectExp(sql));

        }
        [HttpGet]
        public Question ExplainQuestion(string id)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
          return  mysqlhelper.randomById(id);
        }


    }
}
