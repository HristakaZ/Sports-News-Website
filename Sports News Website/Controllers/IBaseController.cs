using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    interface IBaseController<T> : IController
    {
        ActionResult Create();
        ActionResult Create(T entity);
        ActionResult Read();
        ActionResult Update(int? id);
        ActionResult Update(T entity);
        ActionResult Delete(int? id);
        ActionResult Delete(int id);
    }
}