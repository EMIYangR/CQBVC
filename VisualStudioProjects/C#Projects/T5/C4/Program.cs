using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("猜数字游戏开始！");
            int random = new Random().Next(100) + 1,guess;
            do
            {
                Console.Write("请给出一个数字：");
                guess = int.Parse(Console.ReadLine());
                if (guess < random)
                {
                    Console.WriteLine("太小了，再大一点！");
                }
                else if (guess > random)
                {
                    Console.WriteLine("太大了，再小一点！");
                }
                else
                {
                    Console.WriteLine("恭喜你猜对了！");
                }
            } while (guess != random);
        }
    }
}
