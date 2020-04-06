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
            List<Users> users = new List<Users>();
            int id = user.ID;
            if (users.Exists(x => x.Username == user.Username && x.Password == user.Password))
            {
                return RedirectToAction(nameof(Read));
            }
            else if (!users.Exists(x => x.Username == user.Username && x.Password == user.Password))
            {
                return HttpNotFound();
            }
            user = dbContext.Users.Find(id);
            var session = System.Web.HttpContext.Current.Session;
            session.Add("userid", user);
            var sessionUserID = (int)session["userid"];
            /*if (sessionUserID)
            {
                tui za admina (napravi go v atribut)
            }*/
            return View(user);
        }
    }
}