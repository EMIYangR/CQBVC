using System;
using System.Collections.Generic;

namespace C4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (charCount.ContainsKey(input[i]))
                {
                    charCount[input[i]]++;
                }
                else
                {
                    charCount[input[i]] = 1;
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (charCount[input[i]] == 1)
                {
                    Console.WriteLine(input[i].ToString());
                    break;
                }
            }
            Console.WriteLine("");

        }
    }
}
