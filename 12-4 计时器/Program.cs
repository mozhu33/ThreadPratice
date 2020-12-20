using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_4_计时器
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(TimeTask, null, 100, 1000);

            Console.ReadKey();
        }

        private static void TimeTask(object state)
        {
            Console.WriteLine("www.baidu.com");
        }
    }
}
