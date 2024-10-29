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
            Console.WriteLine("请输入一个五位数字：");
            int input = int.Parse(Console.ReadLine());
            int single = input % 10;
            int ten = input / 10 % 10;
            int hundred = input / 100 % 10;
            int thousand = input / 1000 % 10;
            int tenThousand = input / 10000;
            bool result = (tenThousand == single) && (thousand == ten);
            Console.WriteLine("数字{0}是否为回文数字：{1}", input, result);
        }
    }
}
