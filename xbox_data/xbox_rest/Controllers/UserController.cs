using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace xbox_rest.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public Seed GetSeed()
        {
            SeedHelper seedhelper = new SeedHelper();
           return  seedhelper.GetSeed();
        }


        [HttpPost]
        public User LoginUser([FromBody]User user)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            // return "Success";
            var status = mysqlhelper.SearchUser(user);
         
            return status;
        }
        [HttpPost]
        public User Register([FromBody]User user)
        {

            MysqlHelper mysqlhelper = new MysqlHelper();
            mysqlhelper.CreatUser(ref user);
            return user;
        }
        [HttpGet]
        public bool NameSearch(string name)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            return mysqlhelper.SearchName(name);
        }
        [HttpPost]
        public string UpdatePower([FromBody]User user)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
          return   mysqlhelper.UpdatePower(user);
        }

        public User UserStatus([FromBody]User user)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
           return  mysqlhelper.CheckStatus(user);
        }


    }
}
