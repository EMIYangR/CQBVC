using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1,num2;
            Console.WriteLine("请输入两个数字：");
            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());
            int temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("num1={0} num2={1}",num1,num2);
        }
    }
}
