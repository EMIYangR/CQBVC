using System;

namespace T8
{
    class Program
    {
        enum Choice { Rock, Paper, Scissors }

        static void Main(string[] args)
        {
            string[] fistType = new string[] { "剪刀", "石头", "布" };
            Console.WriteLine("-----------------------猜拳游戏---------------------"); ;
            Console.WriteLine("请输入你的出拳数字（1-石头、2-剪刀、3-布，4-退出）：");
            string inputFist = Console.ReadLine();
            while (inputFist != "4")
            {
                Random random = new Random();
                int computerFist = (int)random.Next(1, 3);
                try
                {
                    int personFist = Convert.ToInt32(inputFist);
                    if (personFist > 0 && personFist < 5)
                    {
                        if (personFist < computerFist)
                        {
                            if (personFist == 1 && computerFist == 3)
                            {
                                Console.WriteLine($"你出了{fistType[personFist - 1]}，电脑出了{fistType[computerFist - 1]}，结果你赢了！");
                            }
                            else
                            {
                                Console.WriteLine($"你出了{fistType[personFist - 1]}，电脑出了{fistType[computerFist - 1]}，结果电脑赢了！");
                            }
                        }
                        else if (personFist == computerFist)
                        {
                            Console.WriteLine($"你出了{fistType[personFist - 1]}，电脑出了{fistType[computerFist - 1]}，结果你和电脑平局！");
                        }
                        else
                        {
                            if (personFist == 3 && computerFist == 1)
                            {
                                Console.WriteLine($"你出了{fistType[personFist - 1]}，电脑出了{fistType[computerFist - 1]}，结果电脑赢了！");
                            }
                            else
                            {
                                Console.WriteLine($"你出了{fistType[personFist - 1]}，电脑出了{fistType[computerFist - 1]}，结果你赢了！");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("你输入的数字有误，请重新输入···");
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("请输入你的出拳数字（1-石头、2-剪刀、3-布，4-退出）：");
                inputFist = Console.ReadLine();
            }
        }
    }
}
