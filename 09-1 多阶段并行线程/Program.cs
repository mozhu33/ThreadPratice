using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_1_多阶段并行线程
{
    class Program
    {
        private static Barrier barrier = new Barrier(3, b =>
               Console.WriteLine($"\n第{b.CurrentPhaseNumber + 1}环节的比赛结束，请评分！"));
        static void Main(string[] args)
        {
            //Random模拟每个小组完成一个环节比赛需要的时间
            Thread thread1 = new Thread(() => DoWork("第一小组", new Random().Next(2, 10)));
            Thread thread2 = new Thread(() => DoWork("第二小组", new Random().Next(2, 10)));
            Thread thread3 = new Thread(() => DoWork("第三小组", new Random().Next(2, 10)));

            //三个小组开始比赛
            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.ReadLine();
        }

        public static void DoWork(string name, int seconds)
        {
            //第一环节
            Console.WriteLine($"\n{name}:开始进入第一环节比赛");
            //模拟小组完成环节比赛需要的时间
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"{name}:完成第一环节比赛，等待其他小组");
            //小组完成阶段任务，去休息等待其它小组也完成比赛
            barrier.SignalAndWait();

            //第二环节
            Console.WriteLine($"\n{name}:开始进入第二环节比赛");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"{name}:完成第二环节比赛，等待其他小组");
            barrier.SignalAndWait();

            //第三环节
            Console.WriteLine($"\n{name}:开始进入第三环节比赛");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine($"{name}:完成第三环节比赛，等待其他小组");
            barrier.SignalAndWait();
        }
    }
}
