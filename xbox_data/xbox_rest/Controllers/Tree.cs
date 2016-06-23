using System.Collections.Generic;

namespace xbox_rest.Controllers
{
    public class Tree
    {
        public Tree()
        {
         
        }
        public string name { get; set; }
        List<Tree> list = new List<Tree>();
        public List<Tree> children
        {
            get { return list; }
            set { value = list; }
        }
        itemStyles its = new itemStyles();
       public itemStyles itemStyle
        {
            get { return its; }
            set { value = its; }
        }

       public class itemStyles
        {
            normals nor = new normals();
           public  normals normal
            {
                get { return nor; }
                set { value = nor; }
            }

            public class normals
            {
                labels labs = new labels();
               public string color { get; set; }
              public labels label
                {
                    get { return labs; }
                    set { labs = value; }
                }

              public  class labels
                {
                  public   bool show { get; set; }
                }
            }
        }
    }

    
}