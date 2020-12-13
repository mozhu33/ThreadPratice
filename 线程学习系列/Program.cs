using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程学习系列
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(OneTest);
            thread.Name = "test";
            thread.Start();

            Console.ReadLine();
        }

        public static void OneTest()
        {
            Thread thisThread = Thread.CurrentThread;
            Console.WriteLine("线程标识：" + thisThread.Name);
            Console.WriteLine("当前地域：" + thisThread.CurrentCulture.Name);
            Console.WriteLine("线程执行状态：" + thisThread.IsAlive);
            Console.WriteLine("是否为后台线程：" + thisThread.IsBackground);
            Console.WriteLine("是否为线程池线程：" + thisThread.IsThreadPoolThread);
        }
    }
}
