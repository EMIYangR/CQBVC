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
            int input;
            Console.WriteLine("请输入一个数字：");
            input = int.Parse(Console.ReadLine());
            //常规输出
            //Console.WriteLine(input + "*1=" + input * 1 + "\t" + input +"*2=" + input * 2);
            //Console.WriteLine(input + "*3=" + input * 3 + "\t" + input +"*4=" + input * 4);
            //Console.WriteLine(input + "*5=" + input * 5 + "\t" + input +"*6=" + input * 6);
            //Console.WriteLine(input + "*7=" + input * 7 + "\t" + input +"*8=" + input * 8);
            //Console.WriteLine(input + "*9=" + input * 9 + "\t" + input +"*10=" + input *10);
            //格式化输出
            Console.WriteLine("{0}*{1}={2}\t{0}*{3}={4}",input,1,input * 1,2,input * 2);
            Console.WriteLine("{0}*{1}={2}\t{0}*{3}={4}",input,3,input * 3,4,input * 4);
            Console.WriteLine("{0}*{1}={2}\t{0}*{3}={4}",input,5,input * 5,6,input * 6);
            Console.WriteLine("{0}*{1}={2}\t{0}*{3}={4}",input,7,input * 7,8,input * 8);
            Console.WriteLine("{0}*{1}={2}\t{0}*{3}={4}",input,9,input * 9,10,input * 10);
        }
    }
}
