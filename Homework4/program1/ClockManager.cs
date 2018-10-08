using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock_Manager
{
   class ClockManager
   {
        public delegate void ClockRing();
        public event ClockRing ring;
        public void BeginRing(DateTime time)
        {
            while (true){
                DateTime NowTime = DateTime.Now;
                if (NowTime >= time){
                    ring();
                    break;
                }
            }
        }
        public void Show(){
            Console.Write("响铃时间到！！！");
        }
   }
}
