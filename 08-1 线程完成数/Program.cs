using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08_1_线程完成数
{
    class Program
    {
        //手头上有5件事
        private static CountdownEvent counted = new CountdownEvent(5);
        static void Main(string[] args)
        {
            Console.WriteLine("开始交待任务");
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(DoOne);
                thread.Name = $"{i}";
                thread.Start();
            }
            
            //等待他们都完事
            counted.Wait();

            Console.WriteLine("任务完成，线程退出");
            Console.ReadLine();
        }

        public static void DoOne()
        {
            int n = new Random().Next(0, 10);
            //模拟要n秒才能完成
            Thread.Sleep(TimeSpan.FromSeconds(n));
            //完成了，减去一件事
            counted.Signal();
            Console.WriteLine($"{Thread.CurrentThread.Name}完成一件事儿了");
        }
    }
}
