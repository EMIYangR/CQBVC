using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3
{

    class Program
    {
        public static char GetLevel(int num)
        {
            if (num >= 90)
            {
                return 'A';
            }
            else if (num >= 80)
            {
                return 'B';
            }
            else if (num >= 60)
            {
                return 'C';
            }
            else
            {
                return 'D';
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入学生的英语成绩：");
            int score = int.Parse(Console.ReadLine());
            Console.WriteLine("成绩评测结果：" + GetLevel(score));
        }
    }
}
