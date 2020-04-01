using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sports_News_Website.Models;

namespace Sports_News_Website.Controllers
{
    public class NewsController : Controller, IBaseController<News>
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
                return RedirectToAction(nameof(Read));
            }
            return View();
        }
        [HttpGet]
        public ActionResult Read()
        {
            var news = db.News.ToList();
            return View(news);
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            News news = db.News.Find(id);
            return View(news);
        }
        [HttpPost]
        public ActionResult Update(News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Read));
            }
            else if(!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            News news = db.News.Find(id);
            return View(news);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            News news = db.News.Find(id);
            if (ModelState.IsValid)
            {
                db.News.Remove(news);
                db.SaveChanges();
                return RedirectToAction(nameof(Read));
            }
            else if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return View(news);
        }
    }
}