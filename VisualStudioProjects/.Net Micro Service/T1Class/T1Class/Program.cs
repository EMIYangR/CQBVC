using System;
using System.Threading;
using System.Threading.Tasks;

namespace T1Class
{
    class Program
    {
        static void Main(string[] args)
        {
            BoilWaterAsync();
            Clean();
            Pao();
            Console.ReadKey();
        }
        async static void BoilWaterAsync()
        {
            string res = await BoilWaterA();
            //Thread.Sleep(5000);
            Console.WriteLine(res);
        }
        async static void CleanAsync()
        {
            string res= await CleanA();     // 新开线程
            Console.WriteLine(res);
        }
        static Task<string> CleanA()        // await调用的方法返回值必须为Task<T>
        {
            return Task.Run<string>(() => {
                // 匿名函数方法体 实际断开线程的执行代码
                Thread.Sleep(3000);
                return "清洗茶具...";
            });
        }
        static Task<string> BoilWaterA()        // await调用的方法返回值必须为Task<T>
        {
            return Task.Run<string>(() => {
                // 匿名函数方法体 实际断开线程的执行代码
                Thread.Sleep(5000);
                return "烧开水...";
            });
        }
        static void Clean()
        {
            Thread.Sleep(3000);
            Console.WriteLine("清洗茶具...");
        }
        static void Pao()
        {
            Thread.Sleep(3000);
            Console.WriteLine("泡茶...");
        }
    }
}
