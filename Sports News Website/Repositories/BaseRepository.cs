using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Repositories
{
    public class BaseRepository<T> : Controller, IBaseRepository<T> where T : class, new()
    {
        readonly SportsNewsDBContext dbContext = new SportsNewsDBContext();
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
                dbContext.Entry(entity).State = EntityState.Added;
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Read));
            }
            return View(entity);
        }
        [HttpGet]
        public ActionResult Read()
        {
            var entities = dbContext.Set<T>().ToList();
            return View(entities);
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            T entity = new T();
            entity = dbContext.Set<T>().Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(T entity)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Read));
            }
            else if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            return View(entity);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            T entity = new T();
            entity = dbContext.Set<T>().Find(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            T entity = new T();
            entity = dbContext.Set<T>().Find(id);
            if (ModelState.IsValid)
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
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