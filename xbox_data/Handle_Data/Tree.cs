using Newtonsoft.Json;
using System.Collections.Generic;

namespace Handle_Data
{

    public class Tree
    {
        [JsonIgnore]
        public string Tree_Id { get; set; }
        [JsonIgnore]
        public string Tree_Name { get; set; }
        [JsonIgnore]
        private List<Tree> list = new List<Tree>();
        [JsonIgnore]
        public string Rank { get; set; }
        [JsonIgnore]
        public List<Tree> Tree_List { get { return list; } set { value = list; } }

       
    }
}