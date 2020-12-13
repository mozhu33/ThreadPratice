using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_1_原子操作_自增
{
    class Program
    {
        private static int sum = 0;
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(AddOne);
                thread.Start();
            }

            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Sum=" + sum);

            Console.ReadLine();
        }

        public static void AddOne()
        {
            for (int i = 0; i < 100; i++)
            {
                Interlocked.Increment(ref sum);
            }
        }
    }
}
