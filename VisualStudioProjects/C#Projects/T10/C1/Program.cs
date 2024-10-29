using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1
{
    public enum GameResult
    {
        Wins = 3, Draws = 1, Losses = 0
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入球队前五场比赛结果（Wins|Draws|Losses）:");
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                string str = Console.ReadLine();
                GameResult result = (GameResult)Enum.Parse(typeof(GameResult), str);
                sum += (int)result;
            }
            Console.WriteLine("球队当前积分：" + sum);
        }
    }
}
