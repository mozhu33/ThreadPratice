using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_1_线程等待_SpinWait
{
    class Program
    {
        private static int sum = 0;
        public static bool isCompleted = false;
        static void Main(string[] args)
        {
            new Thread(DoWork).Start();

            //等待上面的线程完成工作
            MySleep();

            Console.WriteLine("sum=" + sum);

            Console.ReadLine();
        }

        private static void MySleep()
        {
            SpinWait wait = new SpinWait();
            while (!isCompleted)
            {
                wait.SpinOnce();    //与Thread.Sleep相比不会发生上下文切换
            }
        }

        private static void DoWork()
        {
            for (int i = 0; i < 100000; i++)
            {
                sum++;
            }
            isCompleted = true;
        }
    }
}
