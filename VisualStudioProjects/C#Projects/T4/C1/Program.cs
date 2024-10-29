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
            Console.WriteLine("请输入是否会员（Y 会员 N 非会员）：");
            char userType = char.Parse(Console.ReadLine());
            Console.WriteLine("请输入购书金额：");
            double money = double.Parse(Console.ReadLine());
            if(userType == 'Y' || userType == 'y' || money >= 100) {
                money *= 0.9;
            }
            Console.WriteLine("实付金额：{0}",money);
        }
    }
}
