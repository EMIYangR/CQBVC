using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = 2.5;
            const double pi = 3.14;
            double C = 2 * pi * r;
            double S = pi * r * r;
            Console.WriteLine("周长：\n" + C);
            Console.WriteLine("面积：\n" + S);
        }
    }
}
