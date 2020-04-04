using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    public class UserController : BaseController<Users>
    {
        [HttpGet]
        public ActionResult Register()
        {
            return base.Create();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {
            return base.Create(user);
        }
    }
}