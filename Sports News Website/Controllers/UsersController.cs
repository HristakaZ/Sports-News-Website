﻿using Sports_News_Website.Models;
using Sports_News_Website.Repositories;
using Sports_News_Website.Services;
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
        //TO DO : move line 41 to line 39 (first get the info from the DB and then set the current user info)
        [HttpPost]
        public ActionResult Login(Users user)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            if (unitOfWork.UserRepository.GetAll().ToList().Exists(x => x.Username == user.Username
            && x.Password == user.Password))
            {
                System.Web.HttpContext.Current.Session["UserName"] = user.Username;
                List<Users> users = unitOfWork.UserRepository.GetAll();
                Users currentUser = users.Where(x => x.Username == user.Username).FirstOrDefault();
                System.Web.HttpContext.Current.Session["UserID"] = currentUser.ID;
                System.Web.HttpContext.Current.Session["UserAuthorization"] = currentUser.IsAdmin;
                SessionService.ID = (int)System.Web.HttpContext.Current.Session["UserID"];
                SessionService.Username = (string)System.Web.HttpContext.Current.Session["UserName"];
                SessionService.IsAdmin = (bool)System.Web.HttpContext.Current.Session["UserAuthorization"];
                return RedirectToAction(nameof(Read));
            }
            else if (!unitOfWork.UserRepository.GetAll().ToList().Exists(x => x.Username == user.Username
            && x.Password == user.Password))
            {
                return HttpNotFound();
            }
            /* TO DO : the code must look something like this (finding a user by his ID, afterwards checking for admin 
             (should be in an attribute))*/
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
            SessionService.ID = 0;
            SessionService.Username = null;
            SessionService.IsAdmin = false;
            return RedirectToAction(nameof(Read));
        }
    }
}