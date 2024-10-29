using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入两个操作数：");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            double result = (double)num1 / num2;
            Console.WriteLine("除法运算结果：{0}",result.ToString("F2"));
        }
    }
}
