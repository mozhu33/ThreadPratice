using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_1_多线程lock
{
    class Program
    {
        private static object obj = new object();
        private static int sum = 0;
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Sum1);
            thread1.Start();

            Thread thread2 = new Thread(Sum2);
            thread2.Start();

            while (true)
            {
                Console.WriteLine($"{DateTime.Now.ToString()}:" + sum);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        public static void Sum1()
        {
            sum = 0;
            lock (obj)
            {
                for (int i = 0; i < 10; i++)
                {
                    sum += i;
                    Console.WriteLine("Sum1");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
        }

        public static void Sum2()
        {
            sum = 0;
            lock (obj)
            {
                for (int i = 0; i < 10; i++)
                {
                    sum += 1;
                    Console.WriteLine("Sum2");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
        }
    }
}
