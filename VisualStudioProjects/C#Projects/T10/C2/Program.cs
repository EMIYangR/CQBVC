using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2
{
    public struct Candidate
    {
        public string Name;// 姓名
        public int Vote;// 得票数
    }
    class Program
    {
        static void Main(string[] args)
        {
            Candidate Candidate1, Candidate2;
            Console.WriteLine("请输入两位候选人的姓名：");
            Candidate1.Name = Console.ReadLine();
            Candidate2.Name = Console.ReadLine();
            Candidate1.Vote = 0;
            Candidate2.Vote = 0;
            Console.WriteLine("开始投票（5次机会）：");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("请输入你支持的候选人姓名：");
                string name = Console.ReadLine();
                if (name == Candidate1.Name)
                {
                    Candidate1.Vote++;
                }
                else if (name == Candidate2.Name)
                {
                    Candidate2.Vote++;
                }
                else
                {
                    Console.WriteLine("无效投票！");
                }
            }
            Console.WriteLine("姓名\t得票");
            Console.WriteLine("{0}\t{1}", Candidate1.Name, Candidate2.Name);
            Console.WriteLine("{0}\t{1}", Candidate1.Vote, Candidate2.Vote);
        }
    }
}
