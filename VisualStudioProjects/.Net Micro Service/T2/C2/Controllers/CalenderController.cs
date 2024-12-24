using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C2.Controllers
{
    public class CalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show(int year, int month)
        {
            int days = 0;
            Boolean isRn = DateTime.IsLeapYear(year);

            int totalDays = 0;
            for (int i = 1900; i < year; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    totalDays += 366;
                }
                else
                {
                    totalDays += 365;
                }
            }
            int beforeDays = 0;
            for (int i = 1; i <= month; i++)
            {
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        days = 31;
                        break;
                    case 2:
                        if (isRn)
                        {
                            days = 29;
                        }
                        else
                        {
                            days = 28;
                        }
                        break;
                    default:
                        days = 30;
                        break;
                }
                if (i < month)
                {
                    beforeDays += days;
                }
            }

            totalDays += beforeDays;

            int fristDaysofMouth = 0;
            int temp = 1 + totalDays % 7;
            if (temp == 7)
            {
                fristDaysofMouth = 0;
            }
            else
            {
                fristDaysofMouth = temp;
            }

            ViewBag.Weeks = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            ViewBag.FristDaysofMouth = fristDaysofMouth;
            ViewBag.Days = days;
            ViewBag.TotalDays = totalDays;

            return View();
        }
    }
}
