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
            Console.WriteLine("1~100之间能够同时被3和4整除的五个最大数字：");
            for(int i = 100,j = 0;i >= 1; i--)
            {
                if(i % 3 == 0 && i % 4 == 0)
                {
                    Console.WriteLine(i);
                    j++;
                    if(j == 5)
                    {
                        break;
                    }
                }
            }
        }
    }
}
