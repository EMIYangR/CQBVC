using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_3.Models;

namespace T3_3.Controllers
{
    public class CustomerController : Controller
    {
        EShopDBContext _db;
        public CustomerController(EShopDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Customers.ToList());
        }
        public IActionResult Detail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Detail(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            Customer customer = _db.Customers.Find(id);
            if (customer!=null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
