using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_1._3_原子操作_Interlocked交换2
{
    class Program
    {
        static void Main(string[] args)
        {
            int location1 = 1;  //比较整数1
            int value = 2;   //要替换的值
            int comparand = 3;  //比较整数2

            Console.WriteLine("运行前：");
            Console.WriteLine($"location1={location1}|value={value}|comparand={comparand}");

            Console.WriteLine("当location1！=comparand时");
            int result = Interlocked.CompareExchange(ref location1, value, comparand);
            Console.WriteLine($"location1={location1}|value={value}|comparand={comparand}");

            Console.WriteLine("当location1==comparand时");
            comparand = 1;
            result = Interlocked.CompareExchange(ref location1, value, comparand);
            Console.WriteLine($"location1={location1}|value={value}|comparand={comparand},location1改变前的值：{result}");

            Console.ReadLine();
        }
    }
}
