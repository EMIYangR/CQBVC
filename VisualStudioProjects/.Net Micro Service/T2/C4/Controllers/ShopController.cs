using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C4.Utils;

namespace C4.Controllers
{
    public class ShopController : Controller
    {
        IProduct _product;
        public ShopController(IProduct product)
        {
            this._product = product;
        }
        public IActionResult Index()
        {
            this._product.ID = 1;
            this._product.Name = "iQOO 11S";
            this._product.Price = 5499;
            ViewBag.p = _product;
            
            return View();
        }
    }
}
