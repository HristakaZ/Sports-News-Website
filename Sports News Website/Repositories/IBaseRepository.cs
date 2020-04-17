using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Repositories
{
    public interface IBaseRepository<T>
    {
        //TO DO : must edit the repository (add CRUD methods)
        ActionResult Create();
        ActionResult Create(T entity);
        ActionResult Read();
        ActionResult Update(int? id);
        ActionResult Update(T entity);
        ActionResult Delete(int? id);
        ActionResult Delete(int id);
        List<T> GetAll();
        T GetByID(int id);
    }
}