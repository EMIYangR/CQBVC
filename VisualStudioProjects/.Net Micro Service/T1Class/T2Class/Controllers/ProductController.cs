using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2Class.Models;

namespace T2Class.Controllers
{
    public class ProductController : Controller
    {
        FreshLiveDBContext _db;
        public ProductController(FreshLiveDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }
    }
}
