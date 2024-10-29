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
            Console.Write("用户名：");
            String userName = Console.ReadLine();
            Console.Write("密码：");
            String userPwd = Console.ReadLine();
            if (userName == "admin" && userPwd == "123456") {
                Console.WriteLine("登录成功，欢迎回来！");
            } else {
                Console.WriteLine("用户名或密码不匹配，请核实！");
            }
        }
    }
}
