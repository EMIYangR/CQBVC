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
            int[] writenExam = new int[5];
            int[] labExam = new int[5];
            double[] scores = new double[5];
            for (int i = 0; i < writenExam.Length; i++)
            {
                Console.WriteLine("第{0}位员工评测分数：", (i + 1));
                Console.Write("理论成绩：");
                writenExam[i] = int.Parse(Console.ReadLine());
                Console.Write("实操成绩：");
                labExam[i] = int.Parse(Console.ReadLine());
                scores[i] = writenExam[i] * 0.4 + labExam[i] * 0.6;
            }
            Console.WriteLine("最终评测成绩：");
            foreach (var item in scores)
            {
                Console.WriteLine(item);
            }
        }
    }
}
