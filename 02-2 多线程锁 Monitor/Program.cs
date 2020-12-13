using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_2_多线程锁_Monitor
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
            bool isGetLock = false;   //标识：当前线程是否获得资源
            //Monitor.Enter(obj);
            try
            {   //为什么要获取两遍锁？？
                Monitor.Enter(obj, ref isGetLock);
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


        //错误示例：标识线程是否获得资源，错误的使用了全局变量。应该使用方法内部新定义的局部变量
        //public static void Test2()
        //{
        //    bool isGetLock = false;   //定义这个变量的用处在哪儿？？
        //                                            //该变量应该是想作为：判断当前线程是否获得资源的标识，但是后续代码中错误的使用了全部变量，应该使用局部变量
        //    Monitor.Enter(obj);
        //    try
        //    {   //为什么要获取两遍锁？？
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
        //            Monitor.Exit(obj);   //当47行代码被注释后，此行抛出：从不同步代码块中调用了对象同步方法异常
        //                                            //原因猜测：此时运行的是线程1，是由线程1获得的资源，线程2无法释放该资源对象？
        //        Console.WriteLine("Test2已经释放资源");
        //    }

        //}
    }
}
