using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_1_线程池ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(MyAction);

            ThreadPool.QueueUserWorkItem(state =>
            {
                Console.WriteLine("任务已被执行2");
            });

            Console.ReadLine();
        }

        private static void MyAction(object state)
        {
            Console.WriteLine("任务已被执行1");
        }
    }
}
