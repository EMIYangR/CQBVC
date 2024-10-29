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
            Console.WriteLine("*************************");
            Console.WriteLine("*\t用户登录\t*");
            Console.WriteLine("*************************");
            String userName,userPwd;
            bool result;
            do {
                Console.Write("用户名：");
                userName = Console.ReadLine();
                Console.Write("密码：");
                userPwd = Console.ReadLine();
                if(userName == "admin" && userPwd == "1234admin")
                {
                    result = true;
                    Console.WriteLine("登录成功，欢迎回来！");
                } else
                {
                    result = false;
                    Console.WriteLine("用户名和密码不匹配，请重新输入！");
                }
            } while (result == false);
        }
    }
}
