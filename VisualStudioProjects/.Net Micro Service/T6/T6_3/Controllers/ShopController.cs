using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T6_3.Models;

namespace T6_3.Controllers
{
    public class ShopController : Controller
    {
        List<Product> products;
        public ShopController()
        {
            products = new List<Product>
            {
                new Product(){Id=1,Name="产品1",Price=9},
                new Product(){Id=2,Name="产品2",Price=8},
                new Product(){Id=3,Name="产品3",Price=7},
                new Product(){Id=4,Name="产品4",Price=6},
                new Product(){Id=5,Name="产品5",Price=5}
            };
        }
        public IActionResult Index()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,abortConnect=false");
            IDatabase redisDB = redis.GetDatabase(0);
            foreach (var item in products)
            {
                redisDB.SortedSetAdd("shop", JsonConvert.SerializeObject(item), Convert.ToDouble(item.Price));
            }
            RedisValue[] sortResult = redisDB.SortedSetRangeByRank("shop", 0, -1, Order.Descending);
            List<Product> list = new List<Product>();
            foreach (var item in sortResult)
            {
                Product p = JsonConvert.DeserializeObject<Product>(item.ToString());
                list.Add(p);
            }
            return View();
        }
        public IActionResult AddCart(int id)
        {
            Dictionary<int, int> shoppingCart = null;
            string cart = HttpContext.Session.GetString("shoppingCart");
            if (string.IsNullOrEmpty(cart))
            {
                shoppingCart = new Dictionary<int, int>();
                shoppingCart.Add(id, 1);
            }
            else
            {
                shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);
                if (!shoppingCart.ContainsKey(id))
                {
                    shoppingCart[id] = 1;
                }
                else
                {
                    shoppingCart[id] += 1;
                }
            }
            HttpContext.Session.SetString("shoppingCart",JsonConvert.SerializeObject(shoppingCart));
            return RedirectToAction("Index");
        }
        public IActionResult RemoveCart(int id)
        {
            Dictionary<int, int> shoppingCart = null;
            string cart = HttpContext.Session.GetString("shoppingCart");
            shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);
            shoppingCart[id] -= 1;
            if (shoppingCart[id]<=0)
            {
                shoppingCart.Remove(id);
            }
            HttpContext.Session.SetString("shoppingCart", JsonConvert.SerializeObject(shoppingCart));
            return RedirectToAction("Index");
        }
    }
}
