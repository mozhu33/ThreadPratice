using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_1._2_进程同步_Mutex接替运行
{
    class Program
    {
        const string name = "www.baidu.com";
        private static Mutex m;
        static void Main(string[] args)
        {
            //WC 还有没有位置
            bool firstInstance;
            m = new Mutex(true, name, out firstInstance);

            //已经有人在WC
            if (!firstInstance)
            {
                //等待运行的实例退出，此进程才能运行
                Console.WriteLine("排队等待");
                m.WaitOne();
                GoWC();
                return;
            }
            GoWC();

            return;
        }

        private static void GoWC()
        {
            Console.WriteLine("开始上wc");
            Thread.Sleep(1000);
            Console.WriteLine("开门");
            Thread.Sleep(1000);
            Console.WriteLine("关门");
            Thread.Sleep(1000);
            Console.WriteLine("XXXX");
            Thread.Sleep(1000);
            Console.WriteLine("开门");
            Thread.Sleep(1000);
            Console.WriteLine("离开WC");
            m.ReleaseMutex();
            Thread.Sleep(1000);
            Console.WriteLine("洗手");
            Thread.Sleep(1000);
        }
    }
}
