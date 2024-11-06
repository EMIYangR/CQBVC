using HotelMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMS.Controllers
{
    public class HomeController : Controller
    {
        public HotelDB db = new HotelDB();

        // 加载数据
        public ActionResult Index()
        {
            return View(db.Room.ToList());
        }

        // 改变房间状态
        public ActionResult Change(int id)
        {
            db.Room.Find(id).Statu = db.Room.Find(id).Statu == 0 ? 1 : 0;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // 删除房间
        public ActionResult Del(int id)
        {
            try
            {
                db.Room.Remove(db.Room.Find(id));
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}