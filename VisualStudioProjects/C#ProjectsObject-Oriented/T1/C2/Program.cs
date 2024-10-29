using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CinemaTicket> list = new List<CinemaTicket>();
            for (int i = 0; i < 70; i++)
            {
                CinemaTicket c = new CinemaTicket();
                c.id = i+1;
                c.cinemaName = "万达影院";
                c.filmName = "大流浪地球2";
                c.filmHall = "07厅";
                if (c.id % 10 == 0)
                {
                    c.seatNo = (c.id / 10) + "排1"+ +c.id % 10 + "座";
                }
                else
                {
                    c.seatNo = (c.id / 10 + 1) + "排0" + c.id % 10 + "座";
                }
                c.runningTime = "2021/9/19 15:40:00";
                c.ticketPrice = 25;
                c.coverCharge = 15;
                c.bookingOfficeClerk = "王健林";
                c.ticketingTime = DateTime.Now.ToLocalTime().ToString(); 

                list.Add(c);
            }
            Console.WriteLine("序号\t座位");
            foreach (var item in list)
            {
                Console.WriteLine(item.id+"\t"+item.seatNo);
            }
            while (true)
            {
                Console.WriteLine("请选择你想要选择的座位号：");
                int a = int.Parse(Console.ReadLine());
                if (a < list.Count)
                {
                    Console.WriteLine("是否确认选择此座位（除yes外其他全视为取消）");
                    string b = Console.ReadLine();
                    if (b == "yes")
                    {
                        list.RemoveAt(a - 1);
                        Console.WriteLine("序号\t座位");
                        foreach (var item in list)
                        {
                            Console.WriteLine(item.id + "\t" + item.seatNo);
                        }
                    }
                    else
                    {
                        Console.WriteLine("取消成功...");
                    }
                }
                else
                {
                    Console.WriteLine("不存在此座位");
                }
            }
        }
    }
}
