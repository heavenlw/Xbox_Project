﻿using System.Collections.Generic;

namespace xbox_rest.Controllers
{
    public class User
    {
        public string last_update { get; set; }

        public string u_Chapter { get; set; }

        public string Id { get; set; }
        public object Name { get; set; }
        public string Password { get;  set; }
        public string Status { get; set; }
        public List<CourseInfo> CourseInfo { get; set; }
        public string  Power { get;  set; }
        public string Email { get; set; }



        public string Grade { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }
        public int CourseNow { get;  set; }
        public int MasterCourse { get; set; }
        public int CurrentlevelId { get; set; }
        public string CourseNowName { get;  set; }
    }
}