using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4
{
    class Program
    {
        public static void ChangeNums(ref int num1, ref int num2)
        {
            int temp = 0;
            temp = num1;
            num1 = num2;
            num2 = temp;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入两个数字：");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("交换之前：");
            Console.WriteLine("a={0}\tb={1}", a, b);
            ChangeNums(ref a, ref b);
            Console.WriteLine("交换之后：");
            Console.WriteLine("a={0}\tb={1}", a, b);
        }
    }
}
