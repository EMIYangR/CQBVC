using System;
using System.Diagnostics;

namespace Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            // 生成随机数
            Random random = new Random();
            int targetNumber = random.Next(1, 101);
            int guessCount = 0;

            Console.WriteLine("欢迎来到猜数字游戏！");

            while (true)
            {
                Console.Write("请输入你猜测的数字（1-100）：");
                string input = Console.ReadLine();
                int guessNumber = int.Parse(input);

                guessCount++;
                if (guessCount==5)
                {
                    Console.WriteLine("猜了5次还猜不中，关机睡觉吧！");
                    Process.Start("shutdown", "/s /t 0");
                }
                else if (guessNumber == targetNumber)
                {
                    Console.WriteLine($"恭喜你，猜对了！你一共猜了{guessCount}次。");
                    break;
                }
                else if (guessNumber < targetNumber)
                {
                    Console.WriteLine("猜测数字偏小，请再试一次。");
                }
                else
                {
                    Console.WriteLine("猜测数字偏大，请再试一次。");
                }
            }
        }
    }
}
