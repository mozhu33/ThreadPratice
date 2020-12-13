using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_1._2_线程通知2
{
    class Program
    {
        //控制第一个线程
        //第一个线程开始时，AutoResetEvent处于终止状态，无需等待信号
        private static AutoResetEvent oneResetEvent = new AutoResetEvent(true);

        //控制第二个线程
        //第二个线程开始时，AutoResetEvent处于非终止状态，需要等待信号
        private static AutoResetEvent twoResetEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            new Thread(DoOne).Start();
            new Thread(DoTwo).Start();

            Console.ReadLine();
        }

        public static void DoOne()
        {
            while (true)
            {
                Console.WriteLine("\n① 按一下键，我就让DoTwo运行");
                Console.ReadKey();
                twoResetEvent.Set();
                oneResetEvent.Reset();
                //等待DoTwo()给我信号
                oneResetEvent.WaitOne();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n DoOne()执行");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void DoTwo()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));

                //等待DoOne()给我信号
                twoResetEvent.WaitOne();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n DoTwo()执行");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n ②按一下键，我让DoOne运行");
                Console.ReadKey();
                oneResetEvent.Set();
                twoResetEvent.Reset();
            }
        }
    }
}
