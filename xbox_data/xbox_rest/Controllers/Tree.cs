using System.Collections.Generic;

namespace xbox_rest.Controllers
{
  public class Tree
    {
        public Tree()
        {
            
        }
        public string name { get; set; }
        public string symbol { get; set; }
        public string itemStyle { get; set; }
        public string symbolSize { get; set; }
        List<Tree> list = new List<Tree>();
        public List<Tree> children
        {
            get { return list; }
            set { value = list; }
        }        
    }
}