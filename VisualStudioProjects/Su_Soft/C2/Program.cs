using System;

namespace C2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (char c in input)
            {
                if (!((c >= 'a') && (c <= 'z')) && c != ',')
                {
                    Console.WriteLine("输入的字符串不在a-z内！");
                    break;
                }
                else
                {
                    string[] strs = input.Split(',');
                    if (strs == null || strs.Length == 0)
                    {
                        Console.WriteLine("");
                        break;
                    }
                    string res = strs[0];
                    for (int i = 1; i < strs.Length; i++)
                    {
                        while (strs[i].IndexOf(res) != 0)
                        {
                            res = res.Substring(0, res.Length - 1);
                            if (res == "")
                            {
                                Console.WriteLine("");
                                break;
                            }
                        }
                    }
                    Console.WriteLine(res);
                    break;
                }
            }
        }
    }
}
