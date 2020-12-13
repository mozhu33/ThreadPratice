using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_1._3_线程启动_委托与lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart start = DelegateThread;

            Thread thread = new Thread(start);
            thread.Name = "Test";
            thread.Start();

            Console.ReadKey();
        }

        public static void DelegateThread()
        {
            OneTest("a", "b", 666, new Program());
        }

        public static void OneTest(string a, string b, int c, Program p)
        {
            Console.WriteLine("新的线程已经启动");
        }
    }
}
