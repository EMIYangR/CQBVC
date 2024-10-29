using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入日期：");
            int year = int.Parse(Console.ReadLine());
            int mouth = int.Parse(Console.ReadLine());
            int date = int.Parse(Console.ReadLine());
            int days = 0;
            for(int i =1;i < mouth; i++)
            {
                switch(mouth){
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        days += 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        days += 30;
                        break;
                    case 2:
                        if((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                        {
                            days += 29;
                        }
                        else
                        {
                            days += 28;
                        }
                        break;
                }
            }
            days += date;
            Console.WriteLine("{0}年{1}月{2}日是当前年的第{3}天",year,mouth,date,days);
        }
    }
}
