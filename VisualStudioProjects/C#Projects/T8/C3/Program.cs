using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3
{
    class Program
    {
        public static void FindNums(int number)
        {
            Console.WriteLine("所有能够被{0}整除的数字：",number);
            for(int i =1;i <= number; i++)
            {
                if(number % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字：");
            int number = int.Parse(Console.ReadLine());
            FindNums(number);
        }
    }
}
