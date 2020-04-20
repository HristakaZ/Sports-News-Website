using DataAccess.Repositories;
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
        protected ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        protected ActionResult Create(T entity)
        {
            baseRepository.Create(entity);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }
        [HttpGet]
        protected ActionResult Read()
        {
            List<T> entities = baseRepository.Read();
            return View(entities);
        }
        [HttpGet]
        protected T GetByID(int id)
        {
            T entity = new T();
            entity = baseRepository.GetByID(id);
            return entity;
        }
        [HttpGet]
        protected ActionResult Update(int id)
        {
            T entity = new T();
            entity = baseRepository.Update(id);
            return View(entity);
        }
        [HttpPost]
        protected ActionResult Update(T entity)
        {
            baseRepository.Update(entity);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }
        [HttpGet]
        protected ActionResult Delete(int? id)
        {
            T entity = new T();
            entity = baseRepository.Delete(id);
            return View(entity);
        }
        [HttpPost]
        protected ActionResult Delete(int id)
        {
            T entity = baseRepository.Delete(id);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }
    }
}