using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_2_线程池_最大最小线程数
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 8; i++)
                ThreadPool.QueueUserWorkItem(state =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine("");
                });

            for (int i = 0; i < 8; i++)
                ThreadPool.QueueUserWorkItem(state =>
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine("");
                });

            Console.WriteLine("此计算机处理器数量：" + Environment.ProcessorCount);

            int maxThreadsCount;
            int maxCompletionPortThreads;
            ThreadPool.GetMaxThreads(out maxThreadsCount, out maxCompletionPortThreads);

            int availableThreadsCount;
            int availableCompletionThreadsCount;
            ThreadPool.GetAvailableThreads(out availableThreadsCount, out availableCompletionThreadsCount);

            int minThreadsCount;
            int minCompletionThreadsCount;
            ThreadPool.GetMinThreads(out minThreadsCount, out minCompletionThreadsCount);

            Console.WriteLine($"当前线程池最大线程数：{maxThreadsCount}");
            Console.WriteLine($"当前线程池可用线程数：{availableThreadsCount}");
            Console.WriteLine($"当前线程池最小线程数：{availableThreadsCount}");

            Console.ReadLine();
        }
    }
}
