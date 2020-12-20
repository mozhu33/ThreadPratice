using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_3_任务取消
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Console.WriteLine("按下回车键，将取消任务");

            new Thread(() => { CancelTask(cts.Token); }).Start();
            new Thread(() => { CancelTask(cts.Token); }).Start();

            Console.ReadKey();

            //取消执行
            cts.Cancel();

            Console.WriteLine("完成");
            Console.ReadKey();
        }

        private static void CancelTask(CancellationToken token)
        {
            Console.WriteLine("第一阶段");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            if (token.IsCancellationRequested)
                return;

            Console.WriteLine("第二阶段");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            if (token.IsCancellationRequested)
                return;

            Console.WriteLine("第三阶段");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            if (token.IsCancellationRequested)
                return;

            Console.WriteLine("第四阶段");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            if (token.IsCancellationRequested)
                return;

            Console.WriteLine("第五阶段");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            if (token.IsCancellationRequested)
                return;
        }
    }
}
