using System;

namespace Hello_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你的昵称：");
           string name= Console.ReadLine();
            Console.WriteLine($"你好，{name}");
            Console.ReadKey();
        }
    }
}
