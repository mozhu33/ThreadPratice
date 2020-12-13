using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10_1_读写锁
{
    class Program
    {
        private static ReaderWriterLockSlim tool = new ReaderWriterLockSlim();
        private static int MaxId = 1;
        public static List<DoWorkModel> orders = new List<DoWorkModel>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        var result = DoSelect(1, MaxId);
                        if (result is null)
                        {
                            Console.WriteLine("获取失败");
                            continue;
                        }
                        foreach (var item in result)
                        {
                            Console.Write($"{item.Id}|");
                        }
                        Console.WriteLine("\n");
                        Thread.Sleep(1000);
                    }
                }).Start();       
            }
            for (int i = 0; i < 2; i++)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        //模拟生成订单
                        var result = DoCreate((new Random().Next(0, 100)).ToString(), DateTime.Now);

                        if (result is null)
                            Console.WriteLine("创建失败");
                        else
                            Console.WriteLine("创建成功");
                    }
                }).Start();
            }

            Console.ReadLine();
        }

        private static DoWorkModel[] DoSelect(int pageNo,int pageSize)
        {
            try
            {
                DoWorkModel[] doWorks;
                tool.EnterReadLock();  //获取读取锁
                doWorks = orders.Skip((pageNo - 1) * pageSize).Take(pageSize).ToArray();
                return doWorks;
            }
            catch
            { }
            finally
            {
                tool.ExitReadLock(); //释放读取锁
            }
            return default;
        }

        private static DoWorkModel DoCreate(string userName, DateTime time)
        {
            try
            {
                tool.EnterUpgradeableReadLock(); //升级
                try
                {
                    tool.EnterWriteLock(); //获取写入锁
                    //写入订单
                    MaxId += 1;
                    DoWorkModel model = new DoWorkModel()
                    {
                        Id = MaxId,
                        UserName = userName,
                        DateTime = time
                    };
                    orders.Add(model);
                    return model;
                }
                catch
                { }
                finally
                {
                    tool.ExitWriteLock(); //释放写入锁
                }
            }
            catch
            { }
            finally
            {
                tool.ExitUpgradeableReadLock(); //降级
            }

            return default;
        }
    }

    public class DoWorkModel
    {
        public int Id { get; set; } //订单号

        public string UserName { get; set; } //客户名称

        public DateTime DateTime { get; set; } //创建时间
    }
}
