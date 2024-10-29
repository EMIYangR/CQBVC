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
            Console.WriteLine("请输入一个字符：");
            char c = char.Parse(Console.ReadLine());
            if (c >= 'a' && c <= 'z')
            {
                Console.WriteLine("该字符为小写字母");
            }
            else if (c >= 'A' && c <= 'Z')
            {
                Console.WriteLine("该字符为大写字母");
            }
            else if (c >= '0' && c <= '9')
            {
                Console.WriteLine("该字符为数字");
            }
            else
            {
                Console.WriteLine("该字符为其他类型字符");
            }
        }
    }
}
