using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C3.Controllers
{
    public class ShopControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
