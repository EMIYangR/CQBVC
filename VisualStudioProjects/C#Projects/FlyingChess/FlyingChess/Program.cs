using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingChess
{
    class Program
    {
		public struct Player
		{
			public string Name;

			public string Sign;

			public int Location;

			public bool State;
		}
		public enum Legend
		{
			Pause,
			Lucky,
			Landmine,
			Tunnel,
			Normal
		}
		public struct Chapter
		{
			public string Name;

			public Legend Type;

			public string Sign;

			public string Rule;
		}
		internal class FlyingChess
		{
			public static void InitRole(ref Player player_A, ref Player player_B)
			{
				Console.WriteLine("-------------------------两人对战-------------------------");
				Console.Write("请玩家1设置角色名称: ");
				player_A.Name = Console.ReadLine();
				player_A.Sign = "Ａ";
				player_A.Location = 0;
				player_A.State = true;
				Console.Write("请玩家2设置角色名称: ");
				player_B.Name = Console.ReadLine();
				player_B.Sign = "Ｂ";
				player_B.Location = 0;
				player_B.State = true;
			}

			public static void InitChapters(Chapter[] chapters)
			{
				chapters[0].Name = "暂停一次";
				chapters[0].Type = Legend.Pause;
				chapters[0].Sign = "■";
				chapters[0].Rule = "下一轮暂停一次";
				chapters[1].Name = "幸运轮盘";
				chapters[1].Type = Legend.Lucky;
				chapters[1].Sign = "¤";
				chapters[1].Rule = "两种选择：交换位置或轰炸对方(退6步)";
				chapters[2].Name = "超级地雷";
				chapters[2].Type = Legend.Landmine;
				chapters[2].Sign = "★";
				chapters[2].Rule = "轰炸对方,对方退6步";
				chapters[3].Name = "时空隧道";
				chapters[3].Type = Legend.Tunnel;
				chapters[3].Sign = "〓";
				chapters[3].Rule = "再前进10步";
				chapters[4].Name = "普通关卡";
				chapters[4].Type = Legend.Normal;
				chapters[4].Sign = "∷";
				chapters[4].Rule = "若对方在此格，将其轰炸回起点";
			}

			public static void InitMap(Chapter[] chapters, Chapter[] map)
			{
				for (int i = 0; i < map.Length; i++)
				{
					ref Chapter reference = ref map[i];
					reference = chapters[4];
				}
				for (int i = 0; i < 4; i++)
				{
					CreatChapter(chapters[i], 5, map);
				}
			}

			public static void CreatChapter(Chapter chapter, int nums, Chapter[] map)
			{
				Random random = new Random();
				int num = 0;
				while (true)
				{
					bool flag = true;
					int num2 = random.Next(100);
					if (num2 != 0 && num2 != 99 && map[num2].Type == Legend.Normal)
					{
						map[num2] = chapter;
						num++;
						if (num == nums)
						{
							break;
						}
					}
				}
			}

			public static void InitGameInfo(ref Player player_A, ref Player player_B, Chapter[] chapters, Chapter[] map)
			{
				InitRole(ref player_A, ref player_B);
				InitChapters(chapters);
				InitMap(chapters, map);
			}

			public static string GetGraph(int i, Player player_A, Player player_B, Chapter[] map)
			{
				if (i == player_A.Location && i == player_B.Location)
				{
					return "@@";
				}
				if (i == player_A.Location)
				{
					return player_A.Sign;
				}
				if (i == player_B.Location)
				{
					return player_B.Sign;
				}
				return map[i].Sign;
			}

			public static void ShowMap(Player player_A, Player player_B, Chapter[] map)
			{
				int num = 0;
				for (int i = 0; i < 30; i++)
				{
					Console.Write(GetGraph(num++, player_A, player_B, map));
				}
				Console.WriteLine();
				for (int i = 0; i < 5; i++)
				{
					for (int j = 0; j < 29; j++)
					{
						Console.Write("  ");
					}
					Console.Write(GetGraph(num++, player_A, player_B, map));
					Console.WriteLine();
				}
				num = 64;
				for (int i = 0; i < 30; i++)
				{
					Console.Write(GetGraph(num--, player_A, player_B, map));
				}
				Console.WriteLine();
				num = 65;
				for (int i = 0; i < 5; i++)
				{
					Console.Write(GetGraph(num++, player_A, player_B, map));
					Console.WriteLine();
				}
				for (int i = 0; i < 30; i++)
				{
					Console.Write(GetGraph(num++, player_A, player_B, map));
				}
				Console.WriteLine();
			}

			public static void ShowGameInfo(Player player_A, Player player_B, Chapter[] chapters, Chapter[] map)
			{
				Console.WriteLine("**********************************************************");
				Console.WriteLine("\t\t\t开始游戏");
				Console.WriteLine("**********************************************************");
				Console.WriteLine("{0}的士兵：A", player_A.Name);
				Console.WriteLine("{0}的士兵：B", player_B.Name);
				Console.WriteLine("图例：");
				for (int i = 0; i < chapters.Length; i++)
				{
					Chapter chapter = chapters[i];
					Console.WriteLine("{0}\t{1}\t{2}", chapter.Sign, chapter.Name, chapter.Rule);
				}
				Console.WriteLine();
				ShowMap(player_A, player_B, map);
			}

			public static bool PlayGameOnce(ref Player player_1, ref Player player_2, Chapter[] map)
			{
				if (player_1.State)
				{
					Console.WriteLine("\n\n" + player_1.Name + ", 请您按任意字母键后回车启动掷骰子： ");
					Console.ReadLine();
					int num = new Random().Next(6) + 1;
					Console.WriteLine("骰子数： " + num);
					GetCurrentLocation(ref player_1, ref player_2, num, map);
					ShowMap(player_1, player_2, map);
				}
				else
				{
					Console.WriteLine("\n" + player_1.Name + "停掷一次！\n");
					player_1.State = true;
				}
				return player_1.Location == 99;
			}

			public static void GetCurrentLocation(ref Player player_1, ref Player player_2, int step, Chapter[] map)
			{
				player_1.Location += step;
				if (player_1.Location < 0)
				{
					player_1.Location = 0;
				}
				else if (player_1.Location > 99)
				{
					player_1.Location = 99;
				}
				switch (map[player_1.Location].Type)
				{
					case Legend.Tunnel:
						Console.WriteLine("|-P  进入时空隧道， 真爽！");
						GetCurrentLocation(ref player_1, ref player_2, 10, map);
						break;
					case Legend.Landmine:
						Console.WriteLine("~:-(  踩到地雷，气死了...");
						GetCurrentLocation(ref player_1, ref player_2, -6, map);
						break;
					case Legend.Lucky:
						Console.WriteLine("\n◆◇◆◇◆欢迎进入幸运轮盘◆◇◆◇◆");
						Console.WriteLine("   请选择一种运气：");
						Console.WriteLine("   1. 交换位置  2. 轰炸");
						switch (int.Parse(Console.ReadLine()))
						{
							case 1:
								{
									int location = player_1.Location;
									player_1.Location = player_2.Location;
									player_2.Location = location;
									break;
								}
							case 2:
								GetCurrentLocation(ref player_2, ref player_1, -6, map);
								break;
						}
						break;
					case Legend.Pause:
						Console.WriteLine("~~>_<~~  要停战一局了。");
						player_1.State = false;
						break;
					case Legend.Normal:
						if (player_1.Location == player_2.Location)
						{
							player_2.Location = 0;
							Console.WriteLine(":-D  哈哈哈哈...踩到了！");
						}
						break;
				}
			}

			public static void PlayGame(Player player_A, Player player_B, Chapter[] map)
			{
				Player player;
				while (true)
				{
					bool flag = true;
					if (PlayGameOnce(ref player_A, ref player_B, map))
					{
						player = player_A;
						break;
					}
					if (PlayGameOnce(ref player_B, ref player_A, map))
					{
						player = player_B;
						break;
					}
				}
				Console.WriteLine("{0}获取游戏胜利！", player.Name);
			}

			private static void Main(string[] args)
			{
				Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
				Console.WriteLine("※\t\t\t\t\t\t\t※");
				Console.WriteLine("※\t\t\t摸鱼飞行棋\t\t\t※");
				Console.WriteLine("※\t\t\t\t\t\t\t※");
				Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
				Console.WriteLine();
				Player player_A = default(Player);
				Player player_B = default(Player);
				Chapter[] map = new Chapter[100];
				Chapter[] chapters = new Chapter[5];
				InitGameInfo(ref player_A, ref player_B, chapters, map);
				ShowGameInfo(player_A, player_B, chapters, map);
				PlayGame(player_A, player_B, map);
			}
		}
	}
}