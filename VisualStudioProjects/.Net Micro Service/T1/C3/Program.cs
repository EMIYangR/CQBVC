using System;
using System.Globalization;

namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************欢迎使用万年历(*************");
            Console.Write("请输入年份: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("请输入月份: ");
            int month = int.Parse(Console.ReadLine());
            int days = 0;
            Boolean isRn = DateTime.IsLeapYear(year);

            int totalDays = 0;
            for (int i = 1900; i < year; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    totalDays += 366;
                }
                else
                {
                    totalDays += 365;
                }
            }
            int beforeDays = 0;
            for (int i = 1; i <= month; i++)
            {
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        days = 31;
                        break;
                    case 2:
                        if (isRn)
                        {
                            days = 29;
                        }
                        else
                        {
                            days = 28;
                        }
                        break;
                    default:
                        days = 30;
                        break;
                }
                if (i < month)
                {
                    beforeDays += days;
                }
            }

            totalDays += beforeDays;

            int fristDaysofMouth = 0;
            int temp = 1 + totalDays % 7;
            if (temp == 7)
            {
                fristDaysofMouth = 0;
            }
            else
            {
                fristDaysofMouth = temp;
            }

            Console.Write("\n日\t一\t二\t三\t四\t五\t六\n");

            for (int i = 0; i < fristDaysofMouth; i++)
                Console.Write("\t");

            for (int i = 1; i <= days; i++)
            {
                Console.Write(i + "\t");
                if ((totalDays + i - 1) % 7 == 5)
                    Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}