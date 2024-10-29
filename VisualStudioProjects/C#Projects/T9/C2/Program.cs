using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2
{
    class Program
    {
        public static int Count(int[] nums, int search)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (search == nums[i])
                {
                    count++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("请输入十个数字：");
            int[] nums = new int[10];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("请输入需要查询的数字：");
            int search = int.Parse(Console.ReadLine());
            Console.WriteLine("数字{0}出现的次数：{1}", search, Count(nums, search));
        }
    }
}
