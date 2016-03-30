using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbox_data
{
    class Program
    {
        static void Main(string[] args)
        {
           
            XboxHelper xbhelper = new XboxHelper();
            XboxHelper.Start();
        }
    }
}
