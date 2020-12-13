using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_1._4_线程启动_lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
              {
                  OneTest("a", "b", 666, new Program());
              });

            thread.Name = "Test";
            thread.Start();

            Console.ReadLine();
        }

        public static void OneTest(string a, string b, int c, Program p)
        {
            Console.WriteLine("新的线程已经启动");
        }
    }
}
