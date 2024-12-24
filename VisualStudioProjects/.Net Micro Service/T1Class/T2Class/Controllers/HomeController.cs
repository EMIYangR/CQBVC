using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using T2Class.Models;
using T2Class.Utils;

namespace T2Class.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IProductService _service;

        private IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IProductService service, IConfiguration config)
        {
            _logger = logger;
            _logger.LogInformation("构造函数中注入ILogger对象");
            _logger.LogWarning("构造函数中注入ILogger对象");

            _service = service;

            _config = config;

           
        }

        public IActionResult Index()
        {
            SiteConfig sc = _config.GetSection("SiteConfig").Get<SiteConfig>();
            ViewBag.SiteConfig = sc;

            //var list = new List<Goods>()
            //{
            //    new Goods(1,"苹果1个",2),
            //    new Goods(2,"手机一部",1999),
            //    new Goods(3,"电脑一台",3999)
            //};

            var list = _service.GetAllGoods();

            return View(list);
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
