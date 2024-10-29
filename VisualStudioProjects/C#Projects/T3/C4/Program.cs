using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入你的会员类型（A VIP会员 B 会员 C 非会员）：");
            char userType = char.Parse(Console.ReadLine());
            Console.WriteLine("请输入您的购物金额：");
            int sumMoney = int.Parse(Console.ReadLine());
            bool result = (userType == 'A' || userType == 'a') ||
                ((userType == 'B' || userType == 'b') && (sumMoney >= 50)) ||
                ((userType == 'C' || userType == 'c') && (sumMoney >= 100));
            Console.WriteLine("会员类型\t购物金额\t是否满足优惠条件");
            Console.WriteLine("{0}\t\t{1}\t\t{2}",userType,sumMoney,result);
        }
    }
}
