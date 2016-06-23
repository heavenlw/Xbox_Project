﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace xbox_rest.Controllers
{
     public class SeedHelper
    {
        string text = "{\"assistID\":\"4036\",\"list\":[{\"level1_courseSectionID\":\"149419\",\"level1_sectionName" +
           "\":\"第21章 一元二次方程\",\"level2_courseSectionID\":\"149420\",\"level2_sectionName\":\"21.1 一元二" +
           "次方程\",\"level3_courseSectionID\":\"\",\"level3_sectionName\":\"\"},{\"level1_courseSection" +
           "ID\":\"149419\",\"level1_sectionName\":\"第21章 一元二次方程\",\"level2_courseSectionID\":\"149421" +
           "\",\"level2_sectionName\":\"21.2 解一元二次方程\",\"level3_courseSectionID\":\"149448\",\"level3_" +
           "sectionName\":\"21.2.1 配方法\"},{\"level1_courseSectionID\":\"149419\",\"level1_sectionNam" +
           "e\":\"第21章 一元二次方程\",\"level2_courseSectionID\":\"149421\",\"level2_sectionName\":\"21.2 解一" +
           "元二次方程\",\"level3_courseSectionID\":\"149449\",\"level3_sectionName\":\"21.2.2 公式法\"},{\"le" +
           "vel1_courseSectionID\":\"149419\",\"level1_sectionName\":\"第21章 一元二次方程\",\"level2_course" +
           "SectionID\":\"149421\",\"level2_sectionName\":\"21.2 解一元二次方程\",\"level3_courseSectionID\"" +
           ":\"149450\",\"level3_sectionName\":\"21.2.3 因式分解法\"},{\"level1_courseSectionID\":\"149419" +
           "\",\"level1_sectionName\":\"第21章 一元二次方程\",\"level2_courseSectionID\":\"149421\",\"level2_s" +
           "ectionName\":\"21.2 解一元二次方程\",\"level3_courseSectionID\":\"149451\",\"level3_sectionName" +
           "\":\"21.2.4 一元二次方程的根与系数的关系\"},{\"level1_courseSectionID\":\"149419\",\"level1_sectionNam" +
           "e\":\"第21章 一元二次方程\",\"level2_courseSectionID\":\"149422\",\"level2_sectionName\":\"21.3 实际" +
           "问题与一元二次方程\",\"level3_courseSectionID\":\"\",\"level3_sectionName\":\"\"},{\"level1_courseS" +
           "ectionID\":\"149423\",\"level1_sectionName\":\"第22章 二次函数\",\"level2_courseSectionID\":\"14" +
           "9424\",\"level2_sectionName\":\"22.1 二次函数的图象和性质\",\"level3_courseSectionID\":\"149452\",\"" +
           "level3_sectionName\":\"22.1.1 二次函数\"},{\"level1_courseSectionID\":\"149423\",\"level1_se" +
           "ctionName\":\"第22章 二次函数\",\"level2_courseSectionID\":\"149424\",\"level2_sectionName\":\"2" +
           "2.1 二次函数的图象和性质\",\"level3_courseSectionID\":\"149453\",\"level3_sectionName\":\"22.1.2 二" +
           "次函数y=ax2的图像和性质\"},{\"level1_courseSectionID\":\"149423\",\"level1_sectionName\":\"第22章 二" +
           "次函数\",\"level2_courseSectionID\":\"149424\",\"level2_sectionName\":\"22.1 二次函数的图象和性质\",\"l" +
           "evel3_courseSectionID\":\"149454\",\"level3_sectionName\":\"22.1.3 二次函数y=a(x-h)2+k的图像和" +
           "性质\"},{\"level1_courseSectionID\":\"149423\",\"level1_sectionName\":\"第22章 二次函数\",\"level2" +
           "_courseSectionID\":\"149424\",\"level2_sectionName\":\"22.1 二次函数的图象和性质\",\"level3_course" +
           "SectionID\":\"149455\",\"level3_sectionName\":\"22.1.4 二次函数y=ax2+bx+c的图像和性质\"},{\"level1" +
           "_courseSectionID\":\"149423\",\"level1_sectionName\":\"第22章 二次函数\",\"level2_courseSectio" +
           "nID\":\"149425\",\"level2_sectionName\":\"22.2 二次函数与一元二次方程\",\"level3_courseSectionID\":\"" +
           "\",\"level3_sectionName\":\"\"},{\"level1_courseSectionID\":\"149423\",\"level1_sectionNam" +
           "e\":\"第22章 二次函数\",\"level2_courseSectionID\":\"149426\",\"level2_sectionName\":\"22.3 实际问题" +
           "与二次函数\",\"level3_courseSectionID\":\"\",\"level3_sectionName\":\"\"},{\"level1_courseSecti" +
           "onID\":\"149427\",\"level1_sectionName\":\"第23章 旋转\",\"level2_courseSectionID\":\"149428\"," +
           "\"level2_sectionName\":\"23.1 图形的旋转\",\"level3_courseSectionID\":\"\",\"level3_sectionNam" +
           "e\":\"\"},{\"level1_courseSectionID\":\"149427\",\"level1_sectionName\":\"第23章 旋转\",\"level2" +
           "_courseSectionID\":\"149429\",\"level2_sectionName\":\"23.2 中心对称\",\"level3_courseSectio" +
           "nID\":\"149456\",\"level3_sectionName\":\"23.2.1 中心对称\"},{\"level1_courseSectionID\":\"149" +
           "427\",\"level1_sectionName\":\"第23章 旋转\",\"level2_courseSectionID\":\"149429\",\"level2_se" +
           "ctionName\":\"23.2 中心对称\",\"level3_courseSectionID\":\"149457\",\"level3_sectionName\":\"2" +
           "3.2.2 中心对称图形\"},{\"level1_courseSectionID\":\"149427\",\"level1_sectionName\":\"第23章 旋转\"" +
           ",\"level2_courseSectionID\":\"149429\",\"level2_sectionName\":\"23.2 中心对称\",\"level3_cour" +
           "seSectionID\":\"149458\",\"level3_sectionName\":\"23.2.3 关于原点对称的点的坐标\"},{\"level1_course" +
           "SectionID\":\"149427\",\"level1_sectionName\":\"第23章 旋转\",\"level2_courseSectionID\":\"149" +
           "430\",\"level2_sectionName\":\"23.3 课题学习  图案设计\",\"level3_courseSectionID\":\"\",\"level3_" +
           "sectionName\":\"\"},{\"level1_courseSectionID\":\"149431\",\"level1_sectionName\":\"第24章 圆" +
           "\",\"level2_courseSectionID\":\"149432\",\"level2_sectionName\":\"24.1 圆的有关性质\",\"level3_c" +
           "ourseSectionID\":\"149433\",\"level3_sectionName\":\"24.1.1 圆\"},{\"level1_courseSection" +
           "ID\":\"149431\",\"level1_sectionName\":\"第24章 圆\",\"level2_courseSectionID\":\"149432\",\"le" +
           "vel2_sectionName\":\"24.1 圆的有关性质\",\"level3_courseSectionID\":\"149434\",\"level3_sectio" +
           "nName\":\"24.1.2 垂直于弦的直径\"},{\"level1_courseSectionID\":\"149431\",\"level1_sectionName\"" +
           ":\"第24章 圆\",\"level2_courseSectionID\":\"149432\",\"level2_sectionName\":\"24.1 圆的有关性质\",\"" +
           "level3_courseSectionID\":\"149435\",\"level3_sectionName\":\"24.1.3 弧、弦、圆心角\"},{\"level1" +
           "_courseSectionID\":\"149431\",\"level1_sectionName\":\"第24章 圆\",\"level2_courseSectionID" +
           "\":\"149432\",\"level2_sectionName\":\"24.1 圆的有关性质\",\"level3_courseSectionID\":\"149436\"," +
           "\"level3_sectionName\":\"24.1.4 圆周角\"},{\"level1_courseSectionID\":\"149431\",\"level1_se" +
           "ctionName\":\"第24章 圆\",\"level2_courseSectionID\":\"149437\",\"level2_sectionName\":\"24.2" +
           " 点和圆、直线和圆的位置关系\",\"level3_courseSectionID\":\"149438\",\"level3_sectionName\":\"24.2.1 点" +
           "和圆的位置关系\"},{\"level1_courseSectionID\":\"149431\",\"level1_sectionName\":\"第24章 圆\",\"leve" +
           "l2_courseSectionID\":\"149437\",\"level2_sectionName\":\"24.2 点和圆、直线和圆的位置关系\",\"level3_c" +
           "ourseSectionID\":\"149439\",\"level3_sectionName\":\"24.2.2 直线和圆的位置关系\"},{\"level1_cours" +
           "eSectionID\":\"149431\",\"level1_sectionName\":\"第24章 圆\",\"level2_courseSectionID\":\"149" +
           "440\",\"level2_sectionName\":\"24.3 正多边形和圆\",\"level3_courseSectionID\":\"\",\"level3_sect" +
           "ionName\":\"\"},{\"level1_courseSectionID\":\"149431\",\"level1_sectionName\":\"第24章 圆\",\"l" +
           "evel2_courseSectionID\":\"149441\",\"level2_sectionName\":\"24.4 弧长和扇形面积\",\"level3_cour" +
           "seSectionID\":\"\",\"level3_sectionName\":\"\"},{\"level1_courseSectionID\":\"149442\",\"lev" +
           "el1_sectionName\":\"第25章 概率初步\",\"level2_courseSectionID\":\"149443\",\"level2_sectionNa" +
           "me\":\"25.1 随机事件与概率\",\"level3_courseSectionID\":\"149444\",\"level3_sectionName\":\"25.1." +
           "1 随机事件\"},{\"level1_courseSectionID\":\"149442\",\"level1_sectionName\":\"第25章 概率初步\",\"le" +
           "vel2_courseSectionID\":\"149443\",\"level2_sectionName\":\"25.1 随机事件与概率\",\"level3_cours" +
           "eSectionID\":\"149445\",\"level3_sectionName\":\"25.1.2 概率\"},{\"level1_courseSectionID\"" +
           ":\"149442\",\"level1_sectionName\":\"第25章 概率初步\",\"level2_courseSectionID\":\"149446\",\"le" +
           "vel2_sectionName\":\"25.2 用列举法求概率\",\"level3_courseSectionID\":\"\",\"level3_sectionName" +
           "\":\"\"},{\"level1_courseSectionID\":\"149442\",\"level1_sectionName\":\"第25章 概率初步\",\"level" +
           "2_courseSectionID\":\"149447\",\"level2_sectionName\":\"25.3 用频率估计概率\",\"level3_courseSe" +
           "ctionID\":\"\",\"level3_sectionName\":\"\"}]}";

        /// <summary>
        /// 根据json文件将章节数据序列化为树结构
        /// </summary>
        /// <returns></returns>
        public Seed GetSeed()
        {

           
            //string json = Properties.Settings.Default.Json;
            JObject jobject = (JObject)JsonConvert.DeserializeObject(text);
            JArray resultArray = (JArray)JsonConvert.DeserializeObject(jobject["list"].ToString());
            List<Seed> seed_list = JsonConvert.DeserializeObject<List<Seed>>(resultArray.ToString());

            //Second(seed_list);

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
                            new_seed.rank = "3";
                            tree.children.Find(Seed => Seed.Id == seed.level1_courseSectionID).children.Find(Seed => Seed.Id == seed.level2_courseSectionID).children.Add(new_seed);
                        }
                    }
                }
            }
            return tree;

        }

        internal List<Seed> GetSeedList()
        {
            JObject jobject = (JObject)JsonConvert.DeserializeObject(text);
            JArray resultArray = (JArray)JsonConvert.DeserializeObject(jobject["list"].ToString());
            List<Seed> seed_list = JsonConvert.DeserializeObject<List<Seed>>(resultArray.ToString());
            return seed_list;
        }
    }
}