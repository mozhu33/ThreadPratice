using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_1._2_线程启动
{
    class Program
    {
        private string A = "成员变量";
        private static string B = "静态变量";

        static void Main(string[] args)
        {
            //创建一个类
            Program p = new Program();

            Thread thread1 = new Thread(p.OneTest1);
            thread1.Name = "Test1";
            thread1.Start();

            Thread thread2 = new Thread(OneTest2);
            thread2.Name = "Test2";
            thread2.Start();

            Console.ReadKey();
        }

        public void OneTest1()
        {
            Console.WriteLine("新的线程已经启动");
            Console.WriteLine(A);  //本身对象的其他成员
        }

        public static void OneTest2()
        {
            Console.WriteLine("新的线程已经启动");
            Console.WriteLine(B);  //全局静态变量
        }
    }
}
