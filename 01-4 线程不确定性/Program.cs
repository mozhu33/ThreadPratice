using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_4_线程不确定性
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Test1);
            Thread thread2 = new Thread(Test2);

            thread1.Start();
            thread2.Start();

            Console.ReadLine();
        }

        public static void Test1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Test1:" + i);
            }
        }

        public static void Test2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Test2:" + i);
            }
        }
    }
}
