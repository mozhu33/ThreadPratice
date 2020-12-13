using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_1_资源池限制
{
    class Program
    {
        //求和
        private static int sum = 0;
        private static Semaphore _pool;

        //判断十个线程是否结束了
        private static int isComplete = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("执行程序");

            //设置允许最大三个线程进入资源池
            //一开始设置为0，就是初始化时允许几个线程进入
            //这里设置为3，后面按下按键时，可以放通三个线程
            _pool = new Semaphore(0, 3);
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(AddOne));
                thread.Start(i + 1);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("任意按下键（不要按关机键）,可以打开资源池");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            //准许三个线程进入
            _pool.Release(3);

            //这里没有任何意义，就单纯为了查看结果
            //等待所有线程完成任务
            while (true)
            {
                if (isComplete >= 10)
                    break;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            Console.WriteLine("Sum=" + sum);

            //释放池
            _pool.Close();

            Console.ReadLine();
        }

        public static void AddOne(object obj)
        {
            Console.WriteLine($"线程{(int)obj}启动，进入队列");
            //进入队列等待
            _pool.WaitOne();
            Console.WriteLine($"第{(int)obj}个线程进入资源池");

            for (int i = 0; i < 10; i++)
            {
                Interlocked.Add(ref sum, 1);
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
            }

            //解除占用的资源池
            _pool.Release();
            isComplete += 1;
            Console.WriteLine($"第{(int)obj}个线程退出资源池");
        }
    }
}
