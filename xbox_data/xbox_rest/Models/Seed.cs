using Newtonsoft.Json;
using System.Collections.Generic;

namespace xbox_rest.Controllers
{
    [JsonObject(IsReference = true)]
    public class Seed
    {
        public string level1_courseSectionID { get; set; }
        public string level1_sectionName { get; set; }
        public string level2_courseSectionID { get; set; }
        public string level2_sectionName { get; set; }
        public string level3_courseSectionID { get; set; }
        public string level3_sectionName { get; set; }
        private List<Seed> list = new List<Seed>();
        public string rank { get; set; }

        public List<Seed> children
        {
            get { return list; }
            set { value = list; }
        }
        public string Id { get; set; }
        public string name { get; set; }
        public string FatherId { get;set; }
        public int Degree_2 { get; set; }
        public int Degree_3 { get; set; }
        public int Degree_1 { get; set; }
    }
}