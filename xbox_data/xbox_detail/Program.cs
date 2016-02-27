using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace xbox_detail
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedHelper seedhelper = new SeedHelper();
            MysqlHelper mysqlhelper = new MysqlHelper();
            HandleHelper handlehelper = new HandleHelper();


            List<Seed> seed_list = mysqlhelper.GetSeed();
            List<Video> video_list = mysqlhelper.GetVideoList();
            foreach (Video one_video in video_list)
            {
                Seed seed = SelectSeed(one_video,seed_list);

                handlehelper.Handle(one_video, seed);
            }
           
        }

        private static Seed SelectSeed(Video one_video, List<Seed> seed_list)
        {
            Seed seed = new Seed();
            return seed;
        }
    }
}
