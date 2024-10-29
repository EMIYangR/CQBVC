using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int a = 92;
            int b = a;
            int c = a + 5;
            int sum = a + b + c;
            Console.WriteLine("总分：{0}",sum);
            */

            /*
            Console.Write("请输入你的姓名：");
            String input = Console.ReadLine();
            Console.WriteLine("这是read():");
            char a = (char)Console.Read();
            Console.WriteLine("read():{0}",a);
            Console.WriteLine("欢迎你：{0}",input);
            */

            Console.Write("请输入你的姓名：");
            String name = Console.ReadLine();
            Console.Write("请输入你的年龄：");
            int age = int.Parse(Console.ReadLine());
            Console.Write("请输入你的薪资：");
            double salary = double.Parse(Console.ReadLine());
            //Console.Write("请输入你的性别：");
            //char sex = char.Parse(Console.ReadLine());
            Console.Write("请输入你的性别（0 男 1 女）：");
            char sex1 = char.Parse(Console.ReadLine());
            String sex = (sex1 == '0' ? "男" : "女");
            Console.Write("请输入你的婚姻状况（0 未婚 1 已婚 2 丧偶）：");
            char marry1 = char.Parse(Console.ReadLine());
            String marry = (marry1 == '0' ? "未婚" : (marry1 == '1' ? "已婚" : "丧偶"));
            Console.WriteLine("姓名：{0}   年龄：{1}   薪资：{2}   性别：{3}   婚姻状况：{4}   年薪：{5}",
                name,age,salary,sex,marry,(salary * 13));



            //Console.ReadKey();
        }
    }
}
