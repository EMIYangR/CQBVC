using System;
using System.Collections.Generic;

namespace C1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int a = target - nums[i];
                if (dict.ContainsKey(a))
                {
                    Console.WriteLine(dict[a].ToString(), i);
                }
                dict[nums[i]] = i;
            }
            Console.WriteLine("");
        }
    }
}
