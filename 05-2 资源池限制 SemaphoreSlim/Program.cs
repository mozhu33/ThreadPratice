using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_2_资源池限制_SemaphoreSlim
{
    class Program
    {
        //求和
        private static int sum = 0;
        private static SemaphoreSlim _pool;

        //判断十个线程是否结束了
        private static int isComplete = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("执行程序");

            _pool = new SemaphoreSlim(0, 3);
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(AddOne));
                thread.Start(i + 1);
            }
            Console.WriteLine("任意按下键（不要按关机键），可以打开资源池");
            Console.ReadKey();

            _pool.Release(3);

            while (true)
            {
                if (isComplete >= 10)
                    break;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            Console.WriteLine("Sum=" + sum);

            _pool.Dispose();
            Console.ReadKey();
        }

        public static void AddOne(object obj)
        {
            Console.WriteLine($"线程{(int)obj}启动，进入队列");
            _pool.Wait();
            Console.WriteLine($"第{(int)obj}个线程进入资源池");

            for (int i = 0; i < 10; i++)
            {
                Interlocked.Add(ref sum, 1);
                Thread.Sleep(TimeSpan.FromMilliseconds(200));
            }

            var count = _pool.Release();
            Console.WriteLine($"还剩{count}个资源可以进入资源池");
            isComplete += 1;
            Console.WriteLine($"第{(int)obj}个线程退出资源池");
        }
    }
}
