using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Handle_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Properties.Settings.Default.json;
            //string json = Properties.Settings.Default.Json;
            JObject jobject = (JObject)JsonConvert.DeserializeObject(text);
            JArray resultArray = (JArray)JsonConvert.DeserializeObject(jobject["list"].ToString());
            List<Seed> seed_list = JsonConvert.DeserializeObject<List<Seed>>(resultArray.ToString());

            //Second(seed_list);

            Seed tree = new Seed();
            Tree sec_tree = new Tree();
            tree.name = "初三数学";

            foreach (Seed seed in seed_list)
            {
                if (seed.level1_courseSectionID.Length > 0)
                {
                   
                    if (tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID) == null)
                    {
                        Seed new_seed = new Seed();
                        new_seed.Id = seed.level1_courseSectionID;
                        new_seed.name = seed.level1_sectionName;
                        
                        tree.children.Add(new_seed);
                        
                    }

                    if (seed.level2_courseSectionID.Length > 0)
                    {
                        if (tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Find(Seed => Seed.Id == seed.level2_courseSectionID) == null)
                        {
                            Seed new_seed = new Seed();
                            new_seed.Id = seed.level2_courseSectionID;
                            new_seed.name = seed.level2_sectionName;
                            tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Add(new_seed);
                        }
                    }
                    if (seed.level3_courseSectionID.Length > 0)
                    {
                        if (tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Find(Seed => Seed.Id  == seed.level2_courseSectionID).children.Find(Seed => Seed.Id == seed.level3_courseSectionID) == null)
                        {
                            Seed new_seed = new Seed();
                            new_seed.Id = seed.level3_courseSectionID;
                            new_seed.name = seed.level3_sectionName;
                            tree.children.Find(Seed => Seed.Id== seed.level1_courseSectionID).children.Find(Seed => Seed.Id == seed.level2_courseSectionID).children.Add(new_seed);
                        }
                    }


                }
            }
            string json = JsonConvert.SerializeObject(tree);
        }

        //private static void Second(List<Seed> seed_list)
        ////{
        ////    if (seed.level1_courseSectionID.Length > 0)
        ////    {
        ////        if (tree.Seed_List.Find(Seed => Seed.level1_courseSectionID == seed.level1_courseSectionID) == null)
        ////        {
        ////            tree.Seed_List.Add(seed);
        ////        }

        ////        if (seed.level2_courseSectionID.Length > 0)
        ////        {
        ////            if (tree.Seed_List.Find(Seed => Seed.level1_courseSectionID == seed.level1_courseSectionID).Seed_List.Find(Seed => Seed.level2_courseSectionID == seed.level2_courseSectionID) == null)
        ////            {
        ////                tree.Seed_List.Find(Seed => Seed.level1_courseSectionID == seed.level1_courseSectionID).Seed_List.Add(seed);
        ////            }
        ////        }
        ////        if (seed.level3_courseSectionID.Length > 0)
        ////        {
        ////            if (tree.Seed_List.Find(Seed => Seed.level1_courseSectionID == seed.level1_courseSectionID).Seed_List.Find(Seed => Seed.level2_courseSectionID == seed.level2_courseSectionID).Seed_List.Find(Seed => Seed.level3_courseSectionID == seed.level3_courseSectionID) == null)
        ////            {
        ////                tree.Seed_List.Find(Seed => Seed.level1_courseSectionID == seed.level1_courseSectionID).Seed_List.Find(Seed => Seed.level2_courseSectionID == seed.level2_courseSectionID).Seed_List.Add(seed);
        ////            }
        ////        }


        ////    }
        //}
    }
}