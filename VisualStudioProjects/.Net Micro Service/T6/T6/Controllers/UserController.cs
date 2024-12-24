using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using T6.Models;

namespace T6.Controllers
{
    public class UserController : Controller
    {
        RedisCache redisClient;
        public UserController()
        {
            RedisCacheOptions options = new RedisCacheOptions();
            options.Configuration = "127.0.0.1:6379,abortConnect=false";
            options.InstanceName = "RedisClient";
            redisClient = new RedisCache(options);
        }
        public IActionResult Index()
        {
            string userInfo = redisClient.GetString("user");
            if (string.IsNullOrEmpty(userInfo))
            {
                return RedirectToAction("Login");
            }
            else
            {
                T6.Models.User user = JsonConvert.DeserializeObject<T6.Models.User>(userInfo);
                return View(user);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string loginId, string loginPwd)
        {
            if (loginId == "admin" && loginPwd == "123456")
            {
                T6.Models.User user = new User
                {
                    UserName = "管理员",
                    Gender = "男",
                    Phone = "139*****090"
                };
                string json = JsonConvert.SerializeObject(user);
                redisClient.SetString("user", json);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
