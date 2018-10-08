using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clock_Manager;
namespace program1
{
   class Program
   {
        static void Main(string[] args)
        {
            ClockManager Clock = new ClockManager();
            DateTime time = DateTime.Parse("2018-10-8 16:10:15");//当计算机时间超该时间时会显示提示
            Clock.ring += new ClockManager.ClockRing(Clock.Show);
            Clock.BeginRing(time);
            Console.ReadKey();
        }
   }
}
