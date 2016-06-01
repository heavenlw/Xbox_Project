﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
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
        [HttpPost]
        public void ReceiveGoal([FromBody]User user)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            mysqlhelper.InsertGoal(user);
           
        }
        [HttpPost]
        public string UpdateCurrentLevel([FromBody]User user)
        {
            MysqlHelper mysqlhelper = new MysqlHelper();
            return mysqlhelper.UpdateCurrentLevel(user);
        }
        /// <summary>
        /// data contains user_id and chapter information
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        public Tree TreeData(string id)
        {
            UserHelper userhelper = new UserHelper();
            MysqlHelper mysqlhelper = new MysqlHelper();
            User one_user = new User();
            one_user.Id = id;
            one_user = mysqlhelper.CheckStatus(one_user);
            Seed final_tree = userhelper.HandleBaidu(one_user);
            string result = "";
            Tree tree = new Tree();
            tree.name = "初中数学上";
            foreach (Seed seed in final_tree.children)
            {
                Tree one_tree_2 = new Tree();
                one_tree_2.name = seed.name;
                foreach(Seed seed_2 in seed.children)
                {
                    Tree tree_3 = new Tree();
                    tree_3.name = seed_2.name;
                    one_tree_2.children.Add(tree_3);

                }
                tree.children.Add(one_tree_2);
            }

           
            return tree;
        }
            [HttpGet]
        public Baidu_Data Updatechapter(string id)
        {
           
           //string chapter = Regex.Match(data, @"\[(.*?)\]").Groups[1].ToString();
            UserHelper userhelper = new UserHelper();
            MysqlHelper mysqlhelper = new MysqlHelper();
            User one_user = new User();
            one_user.Id = id;
            one_user =mysqlhelper.CheckStatus(one_user);
           string old_result=  HandleU_Chapter(one_user);
            Seed final_tree =   userhelper.HandleBaidu(one_user);
            int change_status = 0;
            try
            {
                if ((DateTime.Now - DateTime.Parse(one_user.last_update)).Days > 7)
                {
                    change_status = 1;
                }
            }
            catch (Exception t)
            {
                change_status = 1;
            }
            string result = "";
            if (final_tree == null)
            {
                return null;
            }
            foreach (Seed seed in final_tree.children)
            {
                result += seed.Degree_1 + ",";
            }
            result = result.Substring(0, result.Length - 1);
            try
            {
                string old_date_string = Regex.Match(one_user.u_Chapter, "(.*?):").Groups[1].ToString();
                DateTime old_date = Convert.ToDateTime(old_date_string);
                if (change_status == 1)
                {
                    mysqlhelper.UpdateChapter(id, result);
                }
            }
            catch
            {

            }
            Baidu_Data baidudata = new Baidu_Data();
            baidudata.RadarNow = result;
            baidudata.RadarOld = old_result;
            return baidudata;
           // return mysqlhelper.UpdateChapter(id,chapter);
        }

        private string HandleU_Chapter(User one_user)
        {
            string result = "";
            if (one_user.u_Chapter != null && one_user.u_Chapter.Length > 0)
            {
                result = Regex.Match(one_user.u_Chapter, ":(.*)", RegexOptions.Singleline).Groups[1].ToString();
            }
            return result;
        }
    }
}
