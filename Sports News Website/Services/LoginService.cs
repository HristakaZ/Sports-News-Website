using DataAccess.Repositories;
using DataStructure;
using Sports_News_Website.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Services
{
    public static class LoginService
    {
        public static void Login(Users user)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            System.Web.HttpContext.Current.Session["UserName"] = user.Username;
            List<Users> users = unitOfWork.UserRepository.GetAll();
            Users currentUser = users.Where(x => x.Username == user.Username).FirstOrDefault();
            System.Web.HttpContext.Current.Session["UserID"] = currentUser.ID;
            System.Web.HttpContext.Current.Session["UserAuthorization"] = currentUser.IsAdmin;
            SessionDTO.ID = (int)System.Web.HttpContext.Current.Session["UserID"];
            SessionDTO.Username = (string)System.Web.HttpContext.Current.Session["UserName"];
            SessionDTO.IsAdmin = (bool)System.Web.HttpContext.Current.Session["UserAuthorization"];
        }
    }
}