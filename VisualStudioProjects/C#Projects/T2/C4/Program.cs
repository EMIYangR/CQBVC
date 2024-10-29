using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4
{
    class Program
    {
        static void Main(string[] args)
        {
            int chinese,english,math;
            int num = 0;
            Console.WriteLine("请输入各科成绩：");
            Console.WriteLine("语文：");
            chinese = int.Parse(Console.ReadLine());
            Console.WriteLine("英语：");
            english = int.Parse(Console.ReadLine());
            Console.WriteLine("数学：");
            math = int.Parse(Console.ReadLine());
            num = chinese + english + math;
            Console.WriteLine("各科成绩如下：");
            Console.WriteLine("语文\t英语\t数学");
            Console.WriteLine(chinese + "\t" + english + "\t" + math);
            Console.WriteLine("总分："+num);
        }
    }
}
