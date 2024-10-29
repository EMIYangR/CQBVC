using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketing_MS
{
    class Program
    {
        public struct Train
        {
            public string time;
            public string numTrain;
            public string begin;
            public string end;
            public double price;
            public string num;
            public string user;
        }

        public static string user;
        public static Train[] info;
        public static Train[] userBook;

        //登录选择      1、用户    2、管理员
        public static void Index()
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("==\t开发人员：EMI\t\t=============");
            Console.WriteLine("==\t火车站网上订票系统\t=============");
            Console.WriteLine("==== 欢迎使用火车站网上订票系统，请登入  ====");
            Console.WriteLine("请选择登入方式：");
            Console.WriteLine("1、以普通账户登录");
            Console.WriteLine("2、以管理员账户登录");
            Console.WriteLine("3、退出系统");
            string input = Console.ReadLine();
            while (input != "3")
            {
                string input2 = input;
                string input3 = input2;
                if (!(input3 == "1"))
                {       //登录验证
                    if (input3 == "2")
                    {   //管理员登录验证
                        Console.Write("账号：");
                        string input4 = Console.ReadLine();
                        Console.Write("密码：");
                        string input5 = Console.ReadLine();
                        if (input4 == "admin" && input5 == "1234")
                        {
                            if (Admin() == 2)
                            {
                                Index();
                                input = "3";
                            }
                        }
                        else
                        {
                            Console.WriteLine("账户或密码错误，请重新输入！");
                        }
                    }
                    else
                    {
                        Console.WriteLine("输入错误，请重新选择！");
                        input = Console.ReadLine();
                    }
                    continue;
                }
                Console.Write("账号：");
                user = Console.ReadLine();
                Console.Write("密码：");
                string input6 = Console.ReadLine();
                if (user == "user" && input6 == "1234")
                {       //用户登录验证
                    if (User() == 4)
                    {
                        Index();
                        input = "3";
                    }
                }
                else
                {
                    Console.WriteLine("账户或密码错误，请重新输入！");
                }
            }
        }

        //列车信息查询
        public static int User()
        {
            Console.WriteLine("欢迎您! {0}", user);
            Console.WriteLine("1、列车信息查询");
            Console.WriteLine("2、火车票预订");
            Console.WriteLine("3、火车票退订");
            Console.WriteLine("4、返回主界面");
            Console.WriteLine("请选择操作模块：");
            string input = Console.ReadLine();
            while (input != "4")
            {
                switch (input)
                {
                    case "1":
                        {
                            Console.WriteLine("欢迎查询列车信息，以下是部分列车信息：");
                            for (int i = 0; i < info.Length; i++)
                            {
                                Console.WriteLine("时间\t\t车次\t\t起点\t\t终点\t\t票价");
                                Console.WriteLine("2/14 " + info[i].time + "\t" + info[i].numTrain + "\t\t" + info[i].begin + "\t\t" + info[i].end + "\t\t" + info[i].price + "\n");
                            }
                            Console.WriteLine("为了有更准确的信息，您可选择以下方式来进行精确查询：");
                            if (TrainInfoSelect() == 3)
                            {
                                User();
                                input = "4";
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("欢迎预定车票，以下是部分列车信息：");
                            for (int j = 0; j < info.Length; j++)
                            {
                                Console.WriteLine("时间\t\t车次\t\t起点\t\t终点\t\t票价");
                                Console.WriteLine("2/14 " + info[j].time + "\t" + info[j].numTrain + "\t\t" + info[j].begin + "\t\t" + info[j].end + "\t\t" + info[j].price + "\n");
                            }
                            if (UserBook() == 3)
                            {
                                User();
                                input = "4";
                            }
                            break;
                        }
                    case "3":
                        Console.WriteLine("温馨提示：退票、改签须谨慎！\n");
                        if (UserCancel() == 2)
                        {
                            User();
                            input = "4";
                        }
                        break;
                    default:
                        Console.WriteLine("输入错误，请重新输入！");
                        input = Console.ReadLine();
                        break;
                }
            }
            return 4;
        }

        //管理员功能     1、已订票信息
        public static int Admin()
        {
            Console.WriteLine("欢迎您! admin");
            Console.WriteLine("1、查看已订票信息");
            Console.WriteLine("2、返回主界面");
            Console.WriteLine("请选择操作模块：");
            string input = Console.ReadLine();
            while (input != "2")
            {
                string input2 = input;
                string input3 = input2;
                if (input3 == "1")
                {
                    Console.WriteLine("正在查询当前您账户下的订单情况...");
                    int num = 0;
                    for (int i = 0; i < userBook.Length; i++)
                    {
                        if (userBook[i].time != null)
                        {
                            num++;
                            Console.WriteLine("订单号：00" + userBook[i].num + "\n乘坐人：" + userBook[i].user + "\n出发时间：2/14 " + userBook[i].time + "\n车次：" + userBook[i].numTrain + "\n起始站：" + userBook[i].begin + "\n终点站：" + userBook[i].end + "\n车票总价：" + userBook[i].price + "\n");
                        }
                    }
                    Console.WriteLine("一共有{0}个订单\n", num);
                    Admin();
                    input = "2";
                }
                else
                {
                    Console.WriteLine("输入错误，请重新输入！");
                    input = Console.ReadLine();
                }
            }
            return 2;
        }

        //列车信息查询
        public static int TrainInfoSelect()
        {
            Console.WriteLine("1、站站查询");
            Console.WriteLine("2、车次查询");
            Console.WriteLine("3、取消查询");
            Console.WriteLine("请选择：");
            string input = Console.ReadLine();
            while (input != "3")
            {
                string input2 = input;
                string input3 = input2;
                if (!(input3 == "1"))
                {
                    if (input3 == "2")
                    {
                        Console.Write("请输入要查询的车次：");
                        string input4 = Console.ReadLine();
                        Console.WriteLine("时间\t\t车次\t\t起点\t\t终点\t\t票价");
                        int num = 0;
                        for (int i = 0; i < info.Length; i++)
                        {
                            if (info[i].numTrain == input4)
                            {
                                num++;
                                Console.WriteLine("2/14 " + info[i].time + "\t" + info[i].numTrain + "\t\t" + info[i].begin + "\t\t" + info[i].end + "\t\t" + info[i].price + "\n");
                            }
                        }
                        if (num == 0)
                        {
                            Console.WriteLine("对不起，未找到该车次信息！");
                        }
                        TrainInfoSelect();
                        input = "3";
                    }
                    else
                    {
                        Console.WriteLine("输入错误，请重新输入！");
                        input = Console.ReadLine();
                    }
                    continue;
                }
                Console.Write("请输入起始车站：");
                string input5 = Console.ReadLine();
                Console.Write("请输入终点车站：");
                string input6 = Console.ReadLine();
                Console.WriteLine("时间\t\t车次\t\t起点\t\t终点\t\t票价");
                int num2 = 0;
                for (int j = 0; j < info.Length; j++)
                {
                    if (info[j].begin == input5 && info[j].end == input6)
                    {
                        num2++;
                        Console.WriteLine("2/14 " + info[j].time + "\t" + info[j].numTrain + "\t\t" + info[j].begin + "\t\t" + info[j].end + "\t\t" + info[j].price);
                    }
                }
                Console.WriteLine();
                if (num2 == 0)
                {
                    Console.WriteLine("对不起，未找到此路段车站信息！");
                }
                TrainInfoSelect();
                input = "3";
            }
            return 3;
        }

        //用户查询车票
        public static int UserBook()
        {
            Console.WriteLine("请选择查票方式：");
            Console.WriteLine("1、按乘车区间");
            Console.WriteLine("2、按车次");
            Console.WriteLine("3、退出订票");
            string input = Console.ReadLine();
            while (input != "3")
            {
                string input2 = input;
                string input3 = input2;
                if (!(input3 == "1"))
                {
                    if (input3 == "2")
                    {
                        Console.Write("请输入车次信息：");
                        string input4 = Console.ReadLine();
                        int i;
                        for (i = 0; i < userBook.Length && userBook[i].time != null; i++)
                        {
                        }
                        int num = 0;
                        for (int j = 0; j < info.Length; j++)
                        {
                            if (info[j].numTrain == input4)
                            {
                                num++;
                                Console.WriteLine("您确定乘坐{0}从{1}->{2}的车次为{3}，票价{4}元的列车吗？yes/no", info[j].time, info[j].begin, info[j].end, info[j].numTrain, info[j].price);
                                Console.Write("请确认：");
                                string input5 = Console.ReadLine();
                                if (!(input5 == "yes") && !(input5 == "YES") && !(input5 == "Yes"))
                                {
                                    Console.WriteLine("正在为您取消订单...");
                                    Console.WriteLine("订单已取消！\n");
                                    return 2;
                                }
                                userBook[i].time = info[j].time;
                                userBook[i].numTrain = info[j].numTrain;
                                userBook[i].begin = info[j].begin;
                                userBook[i].end = info[j].end;
                                userBook[i].price = info[j].price;
                                userBook[i].num = (i + 10).ToString();
                                userBook[i].user = user;
                                Console.WriteLine("正在出票，请稍等...");
                                Console.WriteLine("出票成功，正在为您生成订单信息...");
                                Console.WriteLine("订单生成成功，您的订单信息为：");
                                Console.WriteLine("订单号：00" + userBook[i].num + "\n乘坐人：" + userBook[i].user + "\n出发时间：2/14 " + userBook[i].time + "\n车次：" + userBook[i].numTrain + "\n起始站：" + userBook[i].begin + "\n终点站：" + userBook[i].end + "\n车票总价：" + userBook[i].price + "\n");
                            }
                        }
                        Console.WriteLine();
                        if (num == 0)
                        {
                            Console.WriteLine("出票失败，未找到此车次车票信息！");
                        }
                        UserBook();
                        input = "3";
                    }
                    else
                    {
                        Console.WriteLine("输入错误，请重新输入！");
                        input = Console.ReadLine();
                    }
                    continue;
                }
                Console.Write("请输入起始车站：");
                string input6 = Console.ReadLine();
                Console.Write("请输入终点车站：");
                string input7 = Console.ReadLine();
                int k;
                for (k = 0; k < userBook.Length && userBook[k].time != null; k++)
                {
                }
                int num2 = 0;
                for (int l = 0; l < info.Length; l++)
                {
                    if (info[l].begin == input6 && info[l].end == input7)
                    {
                        num2++;
                        Console.WriteLine("您确定乘坐{0}从{1}->{2}的车次为{3}，票价{4}元的列车吗？yes/no", info[l].time, info[l].begin, info[l].end, info[l].numTrain, info[l].price);
                        Console.Write("请确认：");
                        string input8 = Console.ReadLine();
                        if (!(input8 == "yes") && !(input8 == "YES") && !(input8 == "Yes"))
                        {
                            Console.WriteLine("正在为您取消订单...");
                            Console.WriteLine("订单已取消！\n");
                            return 1;
                        }
                        userBook[k].time = info[l].time;
                        userBook[k].numTrain = info[l].numTrain;
                        userBook[k].begin = info[l].begin;
                        userBook[k].end = info[l].end;
                        userBook[k].price = info[l].price;
                        userBook[k].num = (k + 10).ToString();
                        userBook[k].user = user;
                        Console.WriteLine("正在出票，请稍等...");
                        Console.WriteLine("出票成功，正在为您生成订单信息...");
                        Console.WriteLine("订单生成成功，您的订单信息为：");
                        Console.WriteLine("订单号：00" + userBook[k].num + "\n乘坐人：" + userBook[k].user + "\n出发时间：2/14 " + userBook[k].time + "\n车次：" + userBook[k].numTrain + "\n起始站：" + userBook[k].begin + "\n终点站：" + userBook[k].end + "\n车票总价：" + userBook[k].price + "\n");
                    }
                }
                Console.WriteLine();
                if (num2 == 0)
                {
                    Console.WriteLine("出票失败，未找到此路段车票信息！");
                }
                UserBook();
                input = "3";
            }
            return 3;
        }

        //用户车票订单
        public static int UserCancel()
        {
            Console.WriteLine("正在查询当前您账户下的订单情况...");
            int num = 0;
            for (int i = 0; i < userBook.Length; i++)
            {
                if (userBook[i].time != null && userBook[i].user == user)
                {
                    num++;
                    Console.WriteLine("订单号：00" + userBook[i].num + "\n乘坐人：" + userBook[i].user + "\n出发时间：2/14 " + userBook[i].time + "\n车次：" + userBook[i].numTrain + "\n起始站：" + userBook[i].begin + "\n终点站：" + userBook[i].end + "\n车票总价：" + userBook[i].price + "\n");
                }
            }
            Console.WriteLine("一共有{0}个订单", num);
            Console.WriteLine("1、继续退订");
            Console.WriteLine("2、返回");
            Console.Write("请选择：");
            string input = Console.ReadLine();
            while (input != "2")
            {
                string input2 = input;
                string input3 = input2;
                if (input3 == "1")
                {
                    Console.Write("请输入您想退订的订单号（输入0以退出）：");
                    string input4 = Console.ReadLine();
                    if(input4 == "0")
                    {
                        break;
                    }
                    int num2 = 0;
                    for (int j = 0; j < userBook.Length; j++)
                    {
                        if ("00" + userBook[j].num == input4)
                        {
                            userBook[j].time = null;
                            userBook[j].numTrain = null;
                            userBook[j].begin = null;
                            userBook[j].end = null;
                            userBook[j].price = 0.0;
                            Console.WriteLine("正在处理退订...");
                            Console.WriteLine("退订成功！\n");
                            num2++;
                            return 1;
                        }
                    }
                    if (num2 == 0)
                    {
                        Console.WriteLine("不存在该订单号！");
                    }
                }
                else
                {
                    Console.WriteLine("输入错误，请重新输入！");
                    input = Console.ReadLine();
                }
            }
            return 2;
        }

        //管理员后台
        public static int AdminInfo()
        {
            Console.WriteLine("欢迎进入后台订票信息系统");
            Console.WriteLine("1、查看用户订票信息");
            Console.WriteLine("2、退出");
            Console.WriteLine("正在查询当前您账户下的订单情况...");
            int num = 0;
            for (int i = 0; i < userBook.Length; i++)
            {
                if (userBook[i].time != null)
                {
                    num++;
                    Console.WriteLine("订单号：00" + userBook[i].num + "\n乘坐人：" + userBook[i].user + "\n出发时间：2/14 " + userBook[i].time + "\n车次：" + userBook[i].numTrain + "\n起始站：" + userBook[i].begin + "\n终点站：" + userBook[i].end + "\n车票总价：" + userBook[i].price + "\n");
                }
            }
            Console.WriteLine("一共有{0}个订单", num);
            return 2;
        }

        //车站信息
        public static void Main(string[] args)
        {
            info = new Train[8];
            userBook = new Train[5];
            string[] array = new string[8] { "重庆", "昆明", "武汉", "成都", "北京", "上海", "深圳", "杭州" };
            string[] array2 = new string[8] { "杭州", "深圳", "上海", "北京", "成都", "武汉", "昆明", "重庆" };
            for (int i = 0; i < info.Length; i++)
            {
                info[i].time = i + 6 + ":00";
                info[i].numTrain = "D12306" + i;
                info[i].begin = array[i];
                info[i].end = array2[i];
                info[i].price = (i + 1) * 100;
            }
            Index();
        }
    }
}