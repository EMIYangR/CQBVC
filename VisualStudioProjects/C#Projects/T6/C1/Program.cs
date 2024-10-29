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
            Console.Write("请输入学生姓名：");
            String name = Console.ReadLine();
            int score, sum = 0;
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("请输入第{0}门课程的成绩：", i);
                score = int.Parse(Console.ReadLine());
                sum += score;
            }
            Console.WriteLine("{0}同学本次考试总成绩：{1}", name, sum);
        }
    }
}
