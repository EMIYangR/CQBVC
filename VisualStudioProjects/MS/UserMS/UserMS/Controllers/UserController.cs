using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserMS.Models;

namespace UserMS.Controllers
{
    public class UserController : Controller
    {
        private UserDB db = new UserDB();
        // GET: User
        public ActionResult Index()
        {
            ViewBag.Model = db.UserInfo.ToList();
            return View();
        }
        //搜索
        [HttpPost]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.Model = db.UserInfo.ToList();
                return View();
            }
            else
            {
                ViewBag.Model = db.UserInfo.Where(a => a.ID == id).ToList();
                return View();
            }

        }
        public ActionResult Add()
        {
            return View();
        }
        //添加
        [HttpPost]
        public ActionResult Add(string Pwd)
        {
            UserInfo ui = new UserInfo();
            ui.Pwd = Pwd;
            db.UserInfo.Add(ui);
            if (db.SaveChanges() > 0)
            {
                Response.Write("<script>alert('添加成功！')</script>");
                return RedirectToAction("Index");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>;history.go(-1)");
                return View();
            }
        }
        //编辑界面
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo ui = db.UserInfo.Find(id);
            if (ui == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pwd = new SelectList(db.UserInfo, "Pwd", ui.Pwd);
            return View(ui);
        }
        //编辑提交
        [HttpPost]
        public ActionResult Edit(int? id,string Pwd)
        {
            db.UserInfo.Find(id).Pwd = Pwd;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");

        }
        //详情
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo ui = db.UserInfo.Find(id);
            if (ui == null)
            {
                return HttpNotFound();
            }
            return View(ui);
        }
        //删除
        public ActionResult Delete(int id)
        {
            UserInfo ui = db.UserInfo.Find(id);
            db.UserInfo.Remove(ui);
            if (db.SaveChanges() > 0)
            {
                Response.Write("<script>alert('删除成功！')</script>");
                return RedirectToAction("Index");
            }
            else
            {
                Response.Write("<script>alert('删除失败！')</script>");
                return RedirectToAction("Index");
            }
        }
        //释放资源
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}