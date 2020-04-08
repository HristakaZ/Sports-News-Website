using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    public class UsersController : BaseController<Users>
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            SportsNewsDBContext dbContext = new SportsNewsDBContext();
            if (dbContext.Users.ToList().Exists(x => x.Username == user.Username && x.Password == user.Password) &&
                ModelState.IsValid)
            {
                System.Web.HttpContext.Current.Session["LoginUser"] = user;
                Session["UserID"] = user.ID;
                Session["UserName"] = user.Username;
                Session["UserAuthorization"] = user.IsAdmin;
                return RedirectToAction(nameof(Read));
            }
            else if (!dbContext.Users.ToList().Exists(x => x.Username == user.Username && x.Password == user.Password))
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            Session.Remove("LoginUser");
            Session.Remove("UserID");
            Session.Remove("UserName");
            Session.Remove("UserAuthorization");
            return RedirectToAction(nameof(Read));
        }
    }
}