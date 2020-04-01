using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    public class BaseController<T> : Controller, IBaseController<T> where T : SportsNewsDBContext
    {
        SportsNewsDBContext db = new SportsNewsDBContext();
        DbSet<T> entities;
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(T entity)
        {
            if (ModelState.IsValid)
            {
                db.Entry.entities(entity);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Read()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(T entity)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}