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
            int length = 7, width = 4;
            int C = (length + width) * 2; 
            int S = length * width;
            Console.WriteLine("周长：\n" + C);
            Console.WriteLine("面积：\n" + S);
        }
    }
}
