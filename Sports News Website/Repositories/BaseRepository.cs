﻿using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly SportsNewsDBContext dbContext = new SportsNewsDBContext();
        public BaseRepository(SportsNewsDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create()
        {

        }
        public void Create(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Added;
        }
        public List<T> Read()
        {
            var entities = dbContext.Set<T>().ToList();
            return entities;
        }
        public T Update(int id)
        {
            T entity = new T();
            entity = GetByID(id);
            return entity;
        }
        public void Update(T entity)
        {
            //Debugger.Log(0, "state", dbContext.Entry(entity).State.ToString());
            dbContext.Set<T>().AddOrUpdate(entity);
        }
        public T Delete(int? id)
        {
            T entity = new T();
            entity = GetByID(id);
            return entity;
        }
        public T Delete(int id)
        {
            T entity = GetByID(id);
            entity = dbContext.Set<T>().Remove(entity);
            return entity;
        }
        public List<T> GetAll()
        {
            List<T> entities = dbContext.Set<T>().ToList();
            return entities;
        }
        public T GetByID(int? id)
        {
            T entity = new T();
            entity = dbContext.Set<T>().Find(id);
            return entity;
        }
        public T GetByID(int id)
        {
            T entity = new T();
            entity = dbContext.Set<T>().Find(id);
            return entity;
        }
    }
}