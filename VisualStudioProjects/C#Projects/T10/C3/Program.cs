using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3
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
            Console.WriteLine("请输入三位候选人的名字：");
            Candidate[] Ca = new Candidate[3];
            int sum = 0;
            for (int i = 0; i < Ca.Length; i++)
            {
                Ca[i].Name = Console.ReadLine();
                int temp = new Random().Next(10) + 1;
                sum += temp;
                Ca[i].Vote = temp;
            }
            Console.WriteLine("姓名\t得票数\t支持率");
            foreach (var item in Ca)
            {
                Console.WriteLine(item.Name + "\t" + item.Vote + "\t" + ((item.Vote * 100.0) / sum).ToString("F2") + "%");
            }
        }
    }
}
