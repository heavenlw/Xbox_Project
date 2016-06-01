using System;
using System.Collections.Generic;

namespace xbox_rest.Controllers
{
    internal class UserHelper
    {
        public UserHelper()
        {
        }

        internal Seed HandleBaidu(User one_user)
        {

            SeedHelper seedhelper = new SeedHelper();
            List<Seed> seed_list = seedhelper.GetSeedList();
            //Seed seed = seedhelper.GetSeed();
            if (one_user.CourseInfo == null)
            { return null; }
            foreach (CourseInfo course in one_user.CourseInfo)
            {
                try
                {

                    seed_list.Find(Seed => Seed.level3_courseSectionID == course.Id).Degree_3 = int.Parse(course.Degree);
                }
                catch
                {

                }
                try
                {
                    seed_list.Find(Seed => Seed.level2_courseSectionID == course.Id).Degree_2 = int.Parse(course.Degree);
                }
                catch
                {
                }
            }
            Seed tree = new Seed();

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
                        new_seed.rank = "1";

                        tree.children.Add(new_seed);

                    }

                    if (seed.level2_courseSectionID.Length > 0)
                    {
                        if (tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Find(Seed => Seed.Id == seed.level2_courseSectionID) == null)
                        {
                            Seed new_seed = new Seed();
                            new_seed.Id = seed.level2_courseSectionID;
                            new_seed.FatherId = seed.level1_courseSectionID;
                            new_seed.name = seed.level2_sectionName;
                                new_seed.rank = "2";
                            tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Add(new_seed);
                            if (seed.Degree_2 != 0)
                            {
                                tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Find(Seed => Seed.Id == seed.level2_courseSectionID).Degree_2 = seed.Degree_2;
                            }
                        }
                    }
                    if (seed.level3_courseSectionID.Length > 0)
                    {
                        if (tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Find(Seed => Seed.Id == seed.level2_courseSectionID).children.Find(Seed => Seed.Id == seed.level3_courseSectionID) == null)
                        {
                            Seed new_seed = new Seed();
                            new_seed.Id = seed.level3_courseSectionID;
                            new_seed.name = seed.level3_sectionName;
                            new_seed.FatherId = seed.level2_courseSectionID;
                            new_seed.Degree_3 = seed.Degree_3;
                            new_seed.rank = "3";
                            tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Find(Seed => Seed.Id == seed.level2_courseSectionID).children.Add(new_seed);
                            //if (seed.Degree_3 != 0)
                            //{
                            //    tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Find(Seed => Seed.Id == seed.level2_courseSectionID).Degree_3 = seed.Degree_3;
                            //}
                        }
                    }
                }
            }
            for (int t = 0; t < tree.children.Count; t++)
            {

                for (int i = 0; i < tree.children[t].children.Count; i++)
                {
                    int count = tree.children[t].children[i].children.Count;
                    if (count > 0)
                    {
                        int all_degree = 0;
                        for (int c = 0; c < tree.children[t].children[i].children.Count; c++)
                        {
                            all_degree += tree.children[t].children[i].children[c].Degree_3;
                        }
                        var degree_value = all_degree / count;
                        tree.children[t].children[i].Degree_2 = degree_value;
                    }
                  
                }

            }
            for (int t = 0; t < tree.children.Count; t++)
            {
                int count = tree.children[t].children.Count;

                int all_degree = 0;
                for (int i = 0; i < count; i++)
                {
                    all_degree += tree.children[t].children[i].Degree_2;
                }
                var degree_value = all_degree / count;
                tree.children[t].Degree_1 = degree_value;

            }
           return tree;
        }
    }
}