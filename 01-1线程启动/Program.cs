using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_1线程启动
{
    class Program
    {
        static void Main(string[] args)
        {
            string myParam = "abcdef";
            ParameterizedThreadStart parameterized = new ParameterizedThreadStart(OneTest);
            Thread thread = new Thread(parameterized);
            thread.Start(myParam);

            Console.ReadLine();
        }

        public static void OneTest(object obj)
        {
            string str = obj as string;
            if (string.IsNullOrEmpty(str))
                return;

            Console.WriteLine("新的线程已经启动");
            Console.WriteLine(str);
        }
    }
}
