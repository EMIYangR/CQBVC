using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2
{
    class Program
    {
        public static void ShowInfo_C()
        {
            Console.WriteLine("C#语言是目前最流行的编写语言，在本课程中将学习编写程序必备的知识");
        }
        public static void ShowInfo_HTML()
        {
            Console.WriteLine("HTML是构成网页的最主要语言，在本课程中将学习网页设计的基础知识");
        }
        public static void ShowInfo_PS()
        {
            Console.WriteLine("PS是进行网页以及广告设计的最主要工具，在本课程中将学习使用PS工具进行UI设计");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("课程列表：");
            Console.WriteLine("C#课程");
            Console.WriteLine("HTML课程");
            Console.WriteLine("PS课程");
            Console.Write("请选择需要了解的课程：");
            string name = Console.ReadLine();
            switch (name)
            {
                case "C#课程":
                    ShowInfo_C();
                    break;
                case "HTML课程":
                    ShowInfo_HTML();
                    break;
                case "PS课程":
                    ShowInfo_PS();
                    break;
            }

        }
    }
}
