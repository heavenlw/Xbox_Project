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
        public IHttpActionResult qslist()
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            return Ok(mysqlhelper.getQuestion());
        }

        [HttpGet]
        public IHttpActionResult random()
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            return Ok(mysqlhelper.random());
        }
    }
}
