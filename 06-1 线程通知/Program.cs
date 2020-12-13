using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_1_线程通知
{
    class Program
    {
        //线程通知
        private static AutoResetEvent resetEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            new Thread(DoOne).Start();

            //用于不断向另一个线程发送信号
            while (true)
            {
                Console.ReadKey();
                //发送通知，设置终止状态
                resetEvent.Set();
            }
        }

        public static void DoOne()
        {
            Console.WriteLine("等待中，请发出信号允许我运行");

            //等待其它线程发送信号
            resetEvent.WaitOne();

            Console.WriteLine("\n收到信号，继续执行");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }

            //重置为非终止状态
            resetEvent.Reset();
            Console.WriteLine("\n第一阶段运行完毕，请继续给予指示");

            //等待其它线程发送信号
            resetEvent.WaitOne();
            Console.WriteLine("\n 收到信号，继续执行");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            Console.WriteLine("\n 第二阶段运行完毕，线程结束，请手动关闭窗口");
        }
    }
}
