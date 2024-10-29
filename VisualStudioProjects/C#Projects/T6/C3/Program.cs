using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字：");
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for(int i = 1, j = 2;i <= (2 * n - 1); i += 2,j += 2)
            {
                sum += i - j;
            }
            Console.WriteLine("表达式运算结果：{0}",sum);
        }
    }
}
