using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sports_News_Website.Models;

namespace Sports_News_Website.Controllers
{
    public class NewsController : Controller
    {
        SportsNewsDBContext db = new SportsNewsDBContext();
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Read(News news)
        {
            return View(news);
        }
        [HttpGet]
        public ActionResult Update(News news)
        {
            return View(news);
        }
        [HttpPost]
        public ActionResult Update(int id)
        {
            News news = new News();
            if (news.ID == id)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Read");
            }
            return View(news);
        }
        [HttpGet]
        public ActionResult Delete(News news)
        {
            return View(news);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            News news = new News();
            if (news.ID == id)
            {
                db.News.Remove(news);
                db.SaveChanges();
                return RedirectToAction("Read");
            }
            return View(news);
        }
    }
}