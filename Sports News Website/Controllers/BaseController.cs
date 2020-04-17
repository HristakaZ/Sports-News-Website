using Sports_News_Website.Models;
using Sports_News_Website.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    public class BaseController<T> : Controller where T : class, new()
    {
        readonly private BaseRepository<T> baseRepository;
        public BaseController(BaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(T entity)
        {
            baseRepository.Create(entity);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }
        [HttpGet]
        public ActionResult Read()
        {
            List<T> entities = baseRepository.Read();
            return View(entities);
        }
        [HttpGet]
        public T GetByID(int id)
        {
            T entity = new T();
            entity = baseRepository.GetByID(id);
            return entity;
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            T entity = new T();
            entity = baseRepository.Update(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(T entity)
        {
            baseRepository.Update(entity);
            UnitOfWork.UOW.Save();
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            T entity = new T();
            entity = baseRepository.Delete(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Delete(T entity)
        {
            baseRepository.Delete(entity);
            UnitOfWork.UOW.Save();
            return View();
        }
    }
}