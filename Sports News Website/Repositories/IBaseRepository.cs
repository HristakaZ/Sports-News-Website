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
        void Create();
        void Create(T entity);
        List<T> Read();
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetByID(int id);
    }
}