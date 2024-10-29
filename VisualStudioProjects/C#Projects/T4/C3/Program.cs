using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入购物总金额：");
            double sumMoney = double.Parse(Console.ReadLine());
            int price = 0;
            if(sumMoney >= 1000)
            {
                sumMoney *= 0.8;
                price = 200;
            } else if (sumMoney >= 500)
            {
                sumMoney *= 0.85;
                price = 100;
            } else if (sumMoney >= 300)
            {
                sumMoney *= 0.9;
                price = 70;
            }
            Console.WriteLine("实际付款金额：{0}\n获取购物券金额：{1}",sumMoney,price);
        }
    }
}
