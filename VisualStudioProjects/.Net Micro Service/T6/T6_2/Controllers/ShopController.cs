using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T6_2.Models;

namespace T6_2.Controllers
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
            string cart = HttpContext.Session.GetString("shoppingCart");
            if (!string.IsNullOrEmpty(cart))
            {
                Dictionary<int, int> shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);
                var result = shoppingCart.Select(kv =>
                {
                    Product product = products.SingleOrDefault(p => p.Id == kv.Key);
                    return new CartItem
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Amount = kv.Value,
                        Total = product.Price * kv.Value
                    };
                });
                ViewBag.Cart = result;
                ViewBag.CartTotal = result.Sum(p => p.Total);
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
