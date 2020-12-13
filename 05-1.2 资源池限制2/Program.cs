using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_1._2_资源池限制2
{
    class Program
    {
        private static Semaphore _pool;
        static void Main(string[] args)
        {
            _pool = new Semaphore(0, 5);
            _pool.Release(5);
            
            //new Thread(AddOne).Start();  //该方法未等待线程执行结束，主线程便可能会将线程池释放，导致后续抛出异常

            var thread1 = new Thread(AddOne);
            thread1.Start();
            thread1.Join();  //等待thread1执行结束后，主线程再将资源池释放掉。否则会导致，可能主线程先释放了池，thread1还未执行，抛出异常
            //释放池 
           _pool.Close();

            Console.ReadLine();
        }

        public static void AddOne()
        {
            _pool.WaitOne();
            Thread.Sleep(1000);
            int count = _pool.Release();
            Console.WriteLine("在此线程退出资源池前，资源池还有多少线程可以进入？" + count);
        }
    }
}
