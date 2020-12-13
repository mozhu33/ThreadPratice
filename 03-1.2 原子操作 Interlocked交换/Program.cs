using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_1._2_原子操作_Interlocked交换
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 5;

            //改变前的值
            int result1 = Interlocked.Exchange(ref a, 2);

            Console.WriteLine($"a新的值：{a},a改变之前的值：{result1}");
            Console.WriteLine();

            int result2 = Interlocked.Exchange(ref a, b);
            Console.WriteLine($"a新的值：{a},b不会变化的：{b},a之前的值：{result2}");

            Console.ReadLine();
        }
    }
}
