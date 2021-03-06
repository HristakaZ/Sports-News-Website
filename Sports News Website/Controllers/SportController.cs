﻿using DataAccess.Repositories;
using DataStructure;
using Sports_News_Website.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    [CustomAuthentication]
    public class SportController : BaseController<Sports>
    {
        public SportController() : base(UnitOfWork.UOW.SportRepository)
        {

        }
        [HttpGet]
        [CustomAuthorization]
        public new ActionResult Create()
        {
            return base.Create();
        }
        [HttpPost]
        [CustomAuthorization]
        public new ActionResult Create(Sports sport)
        {
            return base.Create(sport);
        }
        [HttpGet]
        public new ActionResult Read()
        {
            return base.Read();
        }
        [HttpGet]
        [CustomAuthorization]
        public new ActionResult Update(int id)
        {
            return base.Update(id);
        }
        [HttpPost]
        [CustomAuthorization]
        public new ActionResult Update(Sports sport)
        {
            return base.Update(sport);
        }
        [HttpGet]
        [CustomAuthorization]
        public new ActionResult Delete(int? id)
        {
            return base.Delete(id);
        }
        [HttpPost]
        [CustomAuthorization]
        public new ActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}