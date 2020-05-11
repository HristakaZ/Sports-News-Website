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
            string salt = "sheldonthemightylittlegeniusman";
            string hashedPassword = HashingPasswordService.GenerateSHA256Hash(user.Password, salt) + salt;
            user.Password = hashedPassword;
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
            string salt = "sheldonthemightylittlegeniusman";
            string hashedPassword = HashingPasswordService.GenerateSHA256Hash(user.Password, salt) + salt;
            user.Password = hashedPassword;
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