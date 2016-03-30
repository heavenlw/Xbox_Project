using System.Collections.Generic;

namespace xbox_rest.Controllers
{
    public class Explain
    {
        List<Video> v_list = new List<Video>();
       public string course_id { get; set; }
        public string word { get; set; }
        public string content { get; set; } 
        public List<Video> video_list { get { return v_list; } set { value = v_list; } }
    }
}