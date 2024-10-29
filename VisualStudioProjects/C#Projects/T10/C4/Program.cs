using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4
{
    class Program
    {
        public struct Candidate
        {
            public string Name;// 姓名
            public int Vote;// 得票数
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入三位候选人的名字：");
            Candidate[] Ca = new Candidate[3];
            int sum = 0, temp = 0;
            for (int i = 0; i < Ca.Length; i++)
            {
                Ca[i].Name = Console.ReadLine();
                sum += temp;
                Ca[i].Vote = temp;
            }
            Console.WriteLine("序号\t姓名\t得票数");
            for (int i = 0; i < Ca.Length; i++)
            {
                Console.WriteLine((i + 1) + "\t" + Ca[i].Name + "\t" + Ca[i].Vote);
            }
            Console.WriteLine("开始进行投票（10次机会）：");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("请输入所支持的候选人序号：");
                string choose = Console.ReadLine();
                if (choose == "1")
                {
                    Ca[0].Vote++;
                }
                else if (choose == "2")
                {
                    Ca[1].Vote++;
                }
                else if (choose == "3")
                {
                    Ca[2].Vote++;
                }
                else
                {
                    Console.WriteLine("无效投票！");
                }
            }
            Console.WriteLine("姓名\t得票数");
            foreach (var item in Ca)
            {
                Console.WriteLine(item.Name + "\t" + item.Vote);
            }
            Candidate max = Ca[0];
            for (int i = 0; i < Ca.Length; i++)
            {
                if (max.Vote < Ca[i].Vote)
                {
                    max = Ca[i];
                }
            }
            Console.Write("投票结果：{0}以{1}票当选！", max.Name, max.Vote);
        }
    }
}
