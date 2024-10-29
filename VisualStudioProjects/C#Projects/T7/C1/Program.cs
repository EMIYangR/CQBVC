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
            Console.WriteLine("请输入六位员工的姓名：");
            string[] names = new string[6];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Console.ReadLine();
            }
            int index = new Random().Next(6);
            Console.WriteLine("当选组长的员工：" + names[index]);
        }
    }
}
