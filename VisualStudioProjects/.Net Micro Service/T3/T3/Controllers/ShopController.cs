using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using T3.Models;

namespace T3.Controllers
{
    public class ShopController : Controller
    {
        private IConfiguration _config;
        private ILogger<ShopController> _logger;
        public ShopController(IConfiguration config,ILogger<ShopController> logger)
        {
            _config = config;

            this._logger = logger;
            logger.LogInformation("获取IConfiguration对象和ILogger对象");
        }
        public IActionResult Index()
        {
            Product p = _config.GetSection("Product").Get<Product>();
            _logger.LogWarning(string.Format("商品名称：{0}和商品价格{1:C}", p.Title, p.Price));
            return View(p);
        }
    }
}
