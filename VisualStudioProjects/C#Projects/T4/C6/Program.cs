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
            int days = 0;
            Console.WriteLine("请输入年份:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入月份:");
            int month = int.Parse(Console.ReadLine());
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    days = 31; break;
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30; break;
                case 2:
                    //判断是否为闰年
                    if ((year % 4 == 0 && year % 100 != 0)|| (year % 400 == 0))
                        days = 29;
                    else
                        days = 28;
                    break;
            }
            Console.WriteLine("{0}年{1}月一共{2}天", year, month, days);

        }
    }
}