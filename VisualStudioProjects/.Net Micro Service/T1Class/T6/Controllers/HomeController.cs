using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using T6.Models;

namespace T6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IConfiguration _config;

        RedisCache redisClient;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;

            _config = config;

            RedisCacheOptions options = new RedisCacheOptions();
            options.Configuration = _config.GetSection("redis").Get<String>();
            options.InstanceName = "RedisClient";
            redisClient = new RedisCache(options);

        }

        public IActionResult Index()
        {
            Product p = new Product()
            {
                ProductID = 1,
                ProductName = "苹果",
                ProductPrice = 2.5
            };

            // Redis:对象 => Json字符串
            string pStr = JsonConvert.SerializeObject(p);
            redisClient.SetString("pObj", pStr);

            //Redis 写字符串
            var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
            redisClient.SetString("TimeNow", DateTime.Now.ToString(), options);



            return View();
        }
        public IActionResult ReadData()
        {
            // Redis 读字符串
            ViewBag.TimeNow = redisClient.GetString("TimeNow");

            string str = redisClient.GetString("pObj");
            Product p = JsonConvert.DeserializeObject<Product>(str);
            ViewBag.P = p;
            return View();
        }
        public IActionResult DelData()
        {
            // Redis 删字符串
            redisClient.Remove("TimeNow");

            return Content("<script>alert('已清空TimeNow字段')</script>");
        }
        public IActionResult Privacy()
        {
            // Session的写入
            HttpContext.Session.SetString("now", "过去、现在、未来，欢迎来到王者荣耀！" + DateTime.Now.ToString());

            return View();
        }
        public IActionResult Show()
        {
            ViewBag.now = HttpContext.Session.GetString("now");
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
