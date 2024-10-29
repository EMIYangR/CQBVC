using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入6个数字：");
            int[] nums = new int[6];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("请输入要查询的数字：");
            int search = int.Parse(Console.ReadLine());
            int index = Array.IndexOf(nums, search);
            Console.WriteLine("需要查找的数字在数组中下标：" + index);
        }
    }
}
