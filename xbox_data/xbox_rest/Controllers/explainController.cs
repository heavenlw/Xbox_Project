using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace xbox_rest.Controllers
{
    public class explainController : ApiController
    {
        [HttpGet]
        public Explain Explain(string id)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
          return  mysqlhelper.GetExplainDetail(id);

        }
    }
}
