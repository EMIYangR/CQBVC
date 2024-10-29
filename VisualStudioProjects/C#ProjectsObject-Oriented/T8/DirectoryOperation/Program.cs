using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("**********选择菜单**********");
                Console.WriteLine("|\t1\t|创建文件夹|");
                Console.WriteLine("|\t2\t|移动文件夹|");
                Console.WriteLine("|\t3\t|删除文件夹|");
                Console.WriteLine("|\t其他\t|退出本程序|");
                Console.WriteLine("****************************");
                Console.WriteLine("*******请选择您的操作*******");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    CreateDirectory();
                }
                else if (input == "2")
                {
                    MoveDirectory();
                }
                else if (input == "3")
                {
                    DeleteDirectory();
                }
                else
                {
                    break;
                }
            }
        }
        private static void CreateDirectory()
        {
            Console.WriteLine("请输入需要创建的文件夹");
            Console.WriteLine(@"例如：D:\Test");
            string path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("文件夹创建成功！");
            }
            else
            {
                Console.WriteLine("文件夹存在！");
            }
        }
        private static void MoveDirectory()
        {
            Console.WriteLine("请输入需要移动的文件夹");
            Console.WriteLine(@"例如：D:\Test");
            string path = Console.ReadLine();
            Console.WriteLine("请输入移动至目标的文件夹");
            Console.WriteLine(@"例如：D:\Test\New");
            string path1 = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Directory.Move(path,path1);
                Console.WriteLine("文件夹移动成功！");
            }
            else
            {
                Console.WriteLine("输入的路径不存在！");
            }
        }
        private static void DeleteDirectory()
        {
            Console.WriteLine("请输入需要删除的文件夹");
            Console.WriteLine(@"例如：D:\Test");
            string path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Directory.Delete(path, true);
                Console.WriteLine("文件夹删除成功！");
            }
            else
            {
                Console.WriteLine("文件夹不存在！");
            }
        }
    }
}
