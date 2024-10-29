using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTMS
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (input != "3")
            {
                Console.WriteLine("请选择：");
                Console.WriteLine("1、普通用户");
                Console.WriteLine("2、管理员用户");
                Console.WriteLine("3、退出");
                Console.WriteLine("请选择：");
                input = Console.ReadLine();

                string user = "", admin = "", pwd = "";

                switch (input)
                {
                    case "1":
                        while (true)
                        {
                            Console.Write("账号：");
                            user = Console.ReadLine();
                            Console.Write("密码：");
                            pwd = Console.ReadLine();

                            if (user == "user" && pwd == "123")
                            {
                                UserOP();
                                break;
                            }
                            else if (user == "abc" && pwd == "123")
                            {
                                UserOP();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("账号密码输入错误！");
                            }
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            Console.Write("账号：");
                            admin = Console.ReadLine();
                            Console.Write("密码：");
                            pwd = Console.ReadLine();

                            if (admin == "admin" && pwd == "123")
                            {
                                AdminOP();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("账号密码输入错误！");
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("谢谢使用！");
                        break;
                    default:
                        Console.WriteLine("输入有误！");
                        break;
                }
            }
        }
        static void UserOP()        //普通用户
        {
            string input = "";
            while (input != "4")
            {
                Console.WriteLine("普通用户操作：");
                Console.WriteLine("1、查票");
                Console.WriteLine("2、订票");
                Console.WriteLine("3、退票");
                Console.WriteLine("4、返回");
                Console.WriteLine("请选择：");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SelectAll();
                        break;
                    case "2":
                        BuyTic();
                        break;
                    case "3":
                        RcbackTic();
                        break;
                    default:
                        Console.WriteLine("输入有误！");
                        break;
                }
            }
        }
        static void AdminOP()       //管理员
        {

        }
        static void SelectAll()     //查票
        {
            List<>
            //List<int> list = new List<int>();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    list.Add(i);

            //    list.Remove(1);
            //}
        }
        static void BuyTic()        //买票
        {

        }
        static void RcbackTic()     //退票
        {

        }
    }
}
