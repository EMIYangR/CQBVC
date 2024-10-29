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
            Console.WriteLine("请输入一个小写字母：");
            char letter = char.Parse(Console.ReadLine());
            letter = (char)(letter - 32);
            Console.WriteLine("对应的大写字母 ：{0}", letter);
        }
    }
}
