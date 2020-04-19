using Sports_News_Website.CustomAttributes;
using Sports_News_Website.Models;
using Sports_News_Website.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    [CustomAuthentication]
    [CustomAuthorization]
    public class SportController : BaseController<Sports>
    {
        public SportController() : base(UnitOfWork.UOW.SportRepository)
        {

        }
    }
}