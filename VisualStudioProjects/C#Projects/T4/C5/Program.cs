using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入乘坐出租车的时间（小时）【1~24】：");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入里程数（千米）：");
            int mileage = int.Parse(Console.ReadLine());
            double cost = 0;
            if (hour >= 7 && hour <= 23)
            {
                cost = 10;
                if (mileage >= 3)
                {
                    cost = (mileage - 3) * 2 + 10;
                }
            }
            else
            {
                cost = 12;
                if (mileage >= 3)
                {
                    cost = (mileage - 3) * 2.5 + 10;
                }
            }
            Console.WriteLine("您本次行驶了：{0}千米，共消费：{1}元",mileage,cost);
        }
    }
}
