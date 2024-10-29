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
            Console.WriteLine("请输入班级人数：");
            int count = int.Parse(Console.ReadLine()),sum = 0,i = 0;
            Console.WriteLine("请输入{0}位学生的成绩：",count);
            while(i < count)
            {
                i++;
                sum += int.Parse(Console.ReadLine());
            }
            double avg = (double)sum / count;
            Console.WriteLine("计算机班平均成绩是：{0}",avg);
        }
    }
}
