using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionA.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            string user = HttpContext.Session.GetString("user");
            if (!string.IsNullOrEmpty(user))
            {
                ViewBag.User = user;
                ViewBag.LoginTime = HttpContext.Session.GetString("loginTime");
                ViewBag.SID = HttpContext.Session.Id;
                return View();
            }
            return View();
            //return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string user, string pwd)
        {
            if (user.Trim() == "admin" && pwd.Trim() == "1234")
            {
                HttpContext.Session.SetString("user", user);
                HttpContext.Session.SetString("loginTime", DateTime.Now.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
