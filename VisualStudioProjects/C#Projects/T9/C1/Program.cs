using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1
{
    class Program
    {
        public static double Calc(int num1, int num2, string op)
        {
            switch (op)
            {
                case "+":
                    return num1 + num2;

                case "-":
                    return num1 - num2;
                    
                case "*":
                    return num1 * num2;
                   
                case "/":
                    return (double)num1 / num2;
                   
                default:
                    return 0;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入两个操作数：");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符：");
            string op = Console.ReadLine();
            Console.WriteLine("运算结果："+Calc(a,b,op).ToString("F2"));
        }
    }
}
