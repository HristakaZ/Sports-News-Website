using DataAccess.Repositories;
using DataStructure;
using Sports_News_Website.DTOs;
using Sports_News_Website.Services;
using Sports_News_Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Controllers
{
    public class UsersController : BaseController<Users>
    {
        public UsersController() : base(UnitOfWork.UOW.UserRepository)
        {

        }
        [HttpGet]
        public ActionResult Register()
        {
            return base.Create();
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                string salt = "sheldonthemightylittlegeniusman";
                string hashedPassword = HashingPasswordService.GenerateSHA256Hash(user.Password, salt) + salt;
                user.Password = hashedPassword;
                user.IsAdmin = false;
                return base.Create(user);
            }
            return View(user);
        }

        [HttpGet]
        public new ActionResult Read()
        {
            return base.Read();
        }

        [HttpGet]
        public new ActionResult Update(int id)
        {
            Users user = new Users();
            user = GetByID(id);
            if (user.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                return base.Update(id);
            }
        }

        [HttpPost]
        public new ActionResult Update(Users user)
        {
            if (user.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else if (SessionDTO.IsAdmin == false)
            {
                user.IsAdmin = false;
            }
            else if (ModelState.IsValid)
            {
                string salt = "sheldonthemightylittlegeniusman";
                string hashedPassword = HashingPasswordService.GenerateSHA256Hash(user.Password, salt) + salt;
                user.Password = hashedPassword;
                return base.Update(user);
            }
            return View(user);
        }

        [HttpGet]
        public new ActionResult Delete(int? id)
        {
            Users user = new Users();
            user = GetByID(id);
            if (user.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                return base.Delete(id);
            }
        }

        [HttpPost]
        public new ActionResult Delete(int id)
        {
            Users user = new Users();
            user = GetByID(id);
            if (user.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                return base.Delete(id);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            string salt = "sheldonthemightylittlegeniusman";
            string hashedPassword = HashingPasswordService.GenerateSHA256Hash(user.Password, salt) + salt;
            if (UnitOfWork.UOW.UserRepository.GetAll().Exists(x => x.Username == user.Username
            && x.Password == hashedPassword))
            {
                LoginService.Login(user);
                return RedirectToAction(nameof(Read));
            }
            else if (UnitOfWork.UOW.UserRepository.GetAll().Exists(x => x.Username == user.Username
            && x.Password == hashedPassword))
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            LogoutService.Logout();
            return RedirectToAction(nameof(Read));
        }
    }
}