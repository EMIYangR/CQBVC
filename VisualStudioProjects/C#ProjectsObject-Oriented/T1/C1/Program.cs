using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T14
{
    class Program
    {
        static void Main(string[] args)
        {
            CinemaTicket c = new CinemaTicket();
            int a = 0;
            c.id = ++a;
            c.cinemaName = "万达影院";
            c.filmName = "流浪地球2";
            c.filmHall = "07厅";
            c.seatNo = "7排07座";
            c.runningTime = "2023/01/22 09:40:00";
            c.ticketPrice = 65;
            c.coverCharge = 15;
            c.bookingOfficeClerk = "王健林";
            c.ticketingTime = "023/01/22 09:00:00";
            Console.WriteLine("编号："+c.id);
            Console.WriteLine("影院名："+c.cinemaName);
            Console.WriteLine("影片名："+c.filmName);
            Console.WriteLine("影厅："+c.filmHall);
            Console.WriteLine("座位："+c.seatNo);
            Console.WriteLine("放映时间："+c.runningTime);
            Console.WriteLine("票价："+c.ticketPrice);
            Console.WriteLine("服务费："+c.coverCharge);
            Console.WriteLine("售票员："+c.bookingOfficeClerk);
            Console.WriteLine("出票时间："+c.ticketingTime);
        }
    }
}
