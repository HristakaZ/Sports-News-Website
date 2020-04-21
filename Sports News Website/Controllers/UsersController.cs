using DataAccess.Repositories;
using DataStructure;
using Sports_News_Website.DTOs;
using Sports_News_Website.Services;
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
            return base.Create(user);
        }

        [HttpGet]
        public new ActionResult Read()
        {
            return base.Read();
        }

        [HttpGet]
        public new ActionResult Update(int id)
        {
            return base.Update(id);
        }

        [HttpPost]
        public new ActionResult Update(Users user)
        {
            return base.Update(user);
        }

        [HttpGet]
        public new ActionResult Delete(int? id)
        {
            return base.Delete(id);
        }

        [HttpPost]
        public new ActionResult Delete(int id)
        {
            return base.Delete(id);
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
            if (unitOfWork.UserRepository.GetAll().ToList().Exists(x => x.Username == user.Username
            && x.Password == user.Password))
            {
                LoginService.Login(user);
                return RedirectToAction(nameof(Read));
            }
            else if (!unitOfWork.UserRepository.GetAll().ToList().Exists(x => x.Username == user.Username
            && x.Password == user.Password))
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