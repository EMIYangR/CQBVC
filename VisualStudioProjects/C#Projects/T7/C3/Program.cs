using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入六位裁判给出的得分：");
            double[] scores = new double[6];
            double max = 0, min = 0, sum=0;
            for(int i= 1; i < scores.Length; i++)
            {
                scores[i] = double.Parse(Console.ReadLine());
                sum += scores[i];
            }
            for(int i= 1; i < scores.Length; i++)
            {
                if(max < scores[i])
                {
                    max = scores[i];
                }

                if(min > scores[i])
                {
                    min = scores[i];
                }
            }
            Console.WriteLine("去掉一个最高分{0}，一个最低分{1}",max,min);
            Console.WriteLine("选手最终得分："+(sum = sum - max - min));
        }
    }
}
