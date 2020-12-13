using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_2_暂停与阻塞
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(OneTest);
            thread.Name = "小弟弟";

            Console.WriteLine($"{DateTime.Now}:大家在吃饭，吃完饭后要带小弟弟逛街");
            Console.WriteLine("吃完饭了");
            Console.WriteLine($"{DateTime.Now}:小弟弟开始玩游戏了");
            thread.Start();

            //化妆5秒
            Console.WriteLine("不管他，姐姐先化妆");
            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"{DateTime.Now}:化完妆，等小弟弟打完游戏");
            thread.Join();

            Console.WriteLine("打完游戏了嘛？" + (!thread.IsAlive ? "true" :"false"));
            Console.WriteLine($"{DateTime.Now}：走，逛街去");
            
            Console.ReadLine();
        }

        public static void OneTest()
        {
            Console.WriteLine(Thread.CurrentThread.Name + "开始打游戏");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{DateTime.Now}:第几局：" + i);
                Thread.Sleep(TimeSpan.FromSeconds(2)); //休眠2秒
            }

            Console.WriteLine(Thread.CurrentThread.Name + "打完了");
        }
    }
}
