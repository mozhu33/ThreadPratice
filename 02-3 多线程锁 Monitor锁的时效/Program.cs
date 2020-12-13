using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_3_多线程锁_Monitor锁的时效
{
    class Program
    {
        private static object obj = new object();
        private static bool acquiredLock = false;
        static void Main(string[] args)
        {
            new Thread(Test1).Start();
            Thread.Sleep(1000);
            new Thread(Test2).Start();

            Console.ReadLine();
        }

        public static void Test1()
        {
            try
            {
                Monitor.Enter(obj, ref acquiredLock);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Test1正在锁定资源");
                    Thread.Sleep(1000);
                }
            }
            catch
            { }
            finally
            {
                if (acquiredLock)
                    Monitor.Exit(obj);
                Console.WriteLine("Test1已经释放资源");
            }
        }

        public static void Test2()
        {
            bool isGetLock = false;
          
            try
            {
                isGetLock = Monitor.TryEnter(obj, 500);
                while (!isGetLock)   //判断当前线程是否获取到了资源，获取到继续执行
                {                             
                    Console.WriteLine("还没有获取到资源，老子不干活了");
                    isGetLock = Monitor.TryEnter(obj, 500);
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Test2正在锁定资源");
                    Thread.Sleep(1000);
                }
            }
            catch
            { }
            finally
            {
                if (isGetLock)
                    Monitor.Exit(obj);
                Console.WriteLine("Test2已经释放资源");
            }
        }

        //使用该方法，不会执行完全执行Try块中的语句，只会执行exit语句。   TryEnter已经获取到了资源
        //public static void Test2()
        //{
        //    bool isGetLock = false;
        //    isGetLock = Monitor.TryEnter(obj, 500);
        //    while (!isGetLock)   //使用该方法，不会执行完全执行Try块中的语句，只会执行exit语句。   TryEnter已经获取到了资源
        //    {                              //最终做判断时，使用的仍为全局变量acquiredLock，该标识为test1获取到资源的标识，，，
        //        Console.WriteLine("还没有获取到资源，老子不干活了");
        //        isGetLock = Monitor.TryEnter(obj, 500);
        //    }

        //    try
        //    {
        //        Monitor.Enter(obj, ref acquiredLock);
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Console.WriteLine("Test2正在锁定资源");
        //            Thread.Sleep(1000);
        //        }
        //    }
        //    catch
        //    { }
        //    finally
        //    {
        //        if (acquiredLock)
        //            Monitor.Exit(obj);
        //        Console.WriteLine("Test2已经释放资源");
        //    }
        //}

        //使用该方法，Test2线程永远不会获取到资源，因为第一次获取不到资源时，直接给return掉了，不会再执行之后的代码
        //public static void Test2()
        //{
        //    bool isGetLock = false;
        //    isGetLock = Monitor.TryEnter(obj, 500);
        //    if (!isGetLock)   //使用该方法，Test2线程永远不会获取到资源，因为第一次获取不到资源时，直接给return掉了，不会再执行之后的代码
        //    {
        //        Console.WriteLine("锁还没有释放，我不干活了");
        //        return;
        //    }

        //    try
        //    {
        //        Monitor.Enter(obj, ref acquiredLock);
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Console.WriteLine("Test2正在锁定资源");
        //            Thread.Sleep(1000);
        //        }
        //    }
        //    catch
        //    { }
        //    finally
        //    {
        //        if (acquiredLock)
        //            Monitor.Exit(obj);
        //        Console.WriteLine("Test2已经释放资源");
        //    }
        //}
    }
}
