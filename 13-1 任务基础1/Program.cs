using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13_1_任务基础1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() =>
              {
                  Console.WriteLine("① 开始执行");
                  Thread.Sleep(TimeSpan.FromSeconds(1));

                  Console.WriteLine("① 执行中");
                  Thread.Sleep(TimeSpan.FromSeconds(1));

                  Console.WriteLine("① 执行即将结束");
              });

            Task task2 = new Task(MyTask);

            task1.Start();
            task2.Start();


            Console.ReadLine();
        }

        private static void MyTask()
        {
            Console.WriteLine("② 开始执行");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine("② 执行中");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            Console.WriteLine("② 执行即将结束");
        }
    }
}
