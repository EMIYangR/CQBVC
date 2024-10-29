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
            Console.WriteLine("请输入您的成绩：");
            Console.Write("笔试：");
            int writeScore = int.Parse(Console.ReadLine());
            Console.Write("机试：");
            int labScore = int.Parse(Console.ReadLine());
            bool result = (writeScore >= 60) && (labScore >= 60);
            Console.WriteLine("笔试\t机试\t是否通过");
            Console.WriteLine("{0}\t{1}\t{2}",writeScore,labScore,result);
        }
    }
}
