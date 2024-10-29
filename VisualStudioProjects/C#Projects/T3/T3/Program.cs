using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你的姓名：");
            String name = Console.ReadLine();
            Console.WriteLine("请输入你的年龄：");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("你的姓名是：{0}\n你的年龄是：{1}",name,age);
        }
    }
}
