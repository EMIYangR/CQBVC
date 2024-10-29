using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字（1~10之间）：");
            int num = int.Parse(Console.ReadLine());
            int i = 0,fac = 1;
            while(i < num)
            {
                i++;
                fac *= i;
            }
            Console.WriteLine("数字{0}的阶乘：{1}",num,fac);
        }
    }
}
