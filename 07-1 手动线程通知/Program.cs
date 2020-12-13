using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_1_手动线程通知
{
    class Program
    {
        private static ManualResetEvent resetEvent = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            new Thread(DoOne).Start();
            while (true)
            {
                Console.ReadKey();
                resetEvent.Set();
            }
        }

        public static void DoOne()
        {
            Console.WriteLine("等待中，请发出信号允许我运行");
            resetEvent.WaitOne();

            //后面的都无效，线程会直接跳过而无需等待
            resetEvent.WaitOne();
            resetEvent.WaitOne();
            resetEvent.WaitOne();
            resetEvent.WaitOne();
            resetEvent.WaitOne();
            Console.WriteLine("线程结束");
        }
    }
}
