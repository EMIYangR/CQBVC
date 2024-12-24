using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using T6_3.Models;

namespace T6_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,abortConnect=false");
            IDatabase redisDB = redis.GetDatabase(0);

            Product p = new Product()
            {
                ProductID = 1,
                ProductName = "苹果",
                ProductPrice = 2.5
            };

            string pStr = JsonConvert.SerializeObject(p);

            // 写String
            redisDB.StringSet("p", pStr, TimeSpan.FromSeconds(60));
            // 读String
            string pStr1 = redisDB.StringGet("p");
            Product p1 = JsonConvert.DeserializeObject<Product>(pStr1);

            // 写HashTable
            redisDB.HashSet("prod1", "name", "苹果");
            redisDB.HashSet("prod1", "price", 2.5);
            redisDB.HashSet("prod1", "id", 1);
            // 读HashTable
            redisDB.HashGet("prod1", "name");
            redisDB.HashGet("prod1", "price");
            redisDB.HashGet("prod1", "id");

            // 写List
            redisDB.ListRightPush("prodList", "苹果");
            redisDB.ListRightPush("prodList", "梨");
            redisDB.ListRightPush("prodList", "草莓");
            // 读List
            redisDB.ListGetByIndex("prodList", 2);

            // 写Set
            redisDB.SetAdd("set1", "足球");
            redisDB.SetAdd("set1", "篮球");
            // 读Set
            redisDB.SetRemove("set1", "足球");

            // 写 SortedSet eg.每个用户被点赞次数
            redisDB.SortedSetAdd("sset1", "Jack", 5);
            redisDB.SortedSetAdd("sset1", "EMI", 999);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
