using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.DTOs
{
    public class SessionDTO
    {
        public static int ID
        {
            get
            {
                return System.Web.HttpContext.Current.Session["UserID"] == null ? 0 : (int)System.Web.HttpContext.Current.Session["UserID"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["UserID"] = value;
            }
        }
        public static string Username
        {
            get
            {
                return System.Web.HttpContext.Current.Session["UserName"] == null ? null : (string)System.Web.HttpContext.Current.Session["UserName"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["UserName"] = value;
            }
        }
        public static bool IsAdmin
        {
            get
            {
                return System.Web.HttpContext.Current.Session["UserAuthorization"] == null ? false : (bool)System.Web.HttpContext.Current.Session["UserAuthorization"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["UserAuthorization"] = value;
            }
        }
        private SessionDTO()
        {

        }
    }
}