using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_1_进程同步_Mutex
{
    class Program
    {
        //第一个程序
        const string name = "www.baidu.com";
        private static Mutex m;
        static void Main(string[] args)
        {
            //本程序是否是Mutex的拥有者
            bool firstInstance;
             m = new Mutex(false, name, out firstInstance);

            if (!firstInstance)
            {
                Console.WriteLine("程序已经在运行！按下回车键退出！");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("程序已经启动");
            Console.WriteLine("按下回车键退出运行！");
            Console.ReadKey();
            m.ReleaseMutex();
            m.Close();
            return;
        }
    }
}
