using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 13, 5, 9, 8, 10, 23, 2, 7, 20, 3, 4, 6 };
            int max = nums[0], min = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                }
                if (min > nums[i])
                {
                    min = nums[i];
                }
            }
            console.writeline("最大值：" + max);
            console.writeline("最小值：" + min);
        }
    }
}
