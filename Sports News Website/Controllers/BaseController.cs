using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    public class BaseController<T> : Controller, IBaseController<T> where T : class, new()
    {
        readonly DbSet<T> db;
        readonly SportsNewsDBContext<T> dbContext = new SportsNewsDBContext<T>();
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
                db.Add(entity);
                dbContext.SaveChanges();
            }
            return View(entity);
        }
        [HttpGet]
        public ActionResult Read()
        {
            var entities = dbContext.Entities.ToList();
            return View(entities);
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            T entity = new T();
            entity = dbContext.Entities.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(T entity)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            else if(!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return View(entity);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            T entity = new T();
            entity = dbContext.Entities.Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            T entity = new T();
            entity = dbContext.Entities.Find(id);
            if (ModelState.IsValid)
            {
                db.Remove(entity);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Read));
            }
            else if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return View(entity);
        }
    }  
}