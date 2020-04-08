using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Repositories
{
    public class SessionUserRepository : Controller
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public SessionUserRepository()
        {
            CheckSessionValues();
        }
        public void CheckSessionValues()
        {
            if (this.ID == 0)
            {
                this.ID = (int)System.Web.HttpContext.Current.Session["UserID"];
            }
            if (this.Username == null)
            {
                this.Username = (string)Session["UserName"];
            }
            if (this.IsAdmin == false)
            {
                this.IsAdmin = (bool)Session["UserAuthorization"];
            }
        }
    }
}