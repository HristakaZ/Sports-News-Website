using Sports_News_Website.Models;
using Sports_News_Website.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    public class UsersController : BaseRepository<Users>
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
            UnitOfWork unitOfWork = new UnitOfWork();
            if (unitOfWork.UserRepository.dbContext.Users.ToList().Exists(x => x.Username == user.Username
            && x.Password == user.Password))
            {
                Session["UserName"] = user.Username;
                return RedirectToAction(nameof(Read));
            }
            else if (!unitOfWork.UserRepository.dbContext.Users.ToList().Exists(x => x.Username == user.Username
            && x.Password == user.Password))
            {
                return HttpNotFound();
            }
            /* TO DO : the code must look something like this (finding a user by his ID, afterwards checking for admin 
             (should be in an attribute)) -- but you should move the logic outside of the login method*/
            Users userID = unitOfWork.UserRepository.GetUserByID(1);
            Session["UserID"] = userID;
            /*foreach (Users userID in users)
            {
                if (users.IsAdmin)
                {

                }
            }*/
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