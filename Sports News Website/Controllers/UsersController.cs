using DataAccess.Repositories;
using DataStructure;
using Sports_News_Website.DTOs;
using Sports_News_Website.Services;
using Sports_News_Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                string hashedPassword = HashingPasswordService.GenerateSHA256Hash(user.Password, salt);
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
            UpdateUserViewModel updateUserViewModel = new UpdateUserViewModel()
            {
                ID = user.ID,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
            if (user.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                return View(updateUserViewModel);
            }
        }

        [HttpPost]
        public new ActionResult Update(UpdateUserViewModel updateUserViewModel)
        {
            if (updateUserViewModel.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else if (SessionDTO.IsAdmin == false)
            {
                updateUserViewModel.IsAdmin = false;
            }
            else if (ModelState.IsValid)
            {
                List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
                Users user = allUsers.Where(x => x.ID == updateUserViewModel.ID).FirstOrDefault();
                user.ID = updateUserViewModel.ID;
                user.Username = updateUserViewModel.Username;
                user.IsAdmin = updateUserViewModel.IsAdmin;
                return base.Update(user);
            }
            return View(updateUserViewModel);
        }
        [HttpGet]
        public ActionResult ChangePassword(int id)
        {
            Users user = GetByID(id);
            ChangeUserPasswordViewModel changeUserPasswordViewModel = new ChangeUserPasswordViewModel()
            {
                ID = user.ID,
                Password = user.Password
            };
            if (user.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                return View(changeUserPasswordViewModel);
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangeUserPasswordViewModel changeUserPasswordViewModel)
        {
            if (changeUserPasswordViewModel.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }
            if (ModelState.IsValid)
            {
                string salt = "sheldonthemightylittlegeniusman";
                string hashedPassword = HashingPasswordService.GenerateSHA256Hash(changeUserPasswordViewModel.Password, salt);
                changeUserPasswordViewModel.Password = hashedPassword;
                List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
                Users user = allUsers.Where(x => x.ID == changeUserPasswordViewModel.ID).FirstOrDefault();
                user.Password = changeUserPasswordViewModel.Password;
                return base.Update(user);
            }
            return View(changeUserPasswordViewModel);
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
            string hashedPassword = HashingPasswordService.GenerateSHA256Hash(user.Password, salt);
            List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();
            if (allUsers.Exists(x => x.Username == user.Username && x.Password == hashedPassword))
            {
                LoginService.Login(user);
                return RedirectToAction(nameof(Read));
            }
            else
            {
                ModelState.AddModelError("", "Wrong username or password!");
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