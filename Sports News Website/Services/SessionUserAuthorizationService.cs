using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Services
{
    public class SessionUserAuthorizationService 
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public SessionUserAuthorizationService()
        {
            SetSessionValues();
        }
        public virtual void SetSessionValues()
        {
            if (this.ID == 0)
            {
                this.ID = (int)System.Web.HttpContext.Current.Session["UserID"];
            }
            if (this.Username == null)
            {
                this.Username = (string)System.Web.HttpContext.Current.Session["UserName"];
            }
            if (this.IsAdmin == false)
            {
                this.IsAdmin = (bool)System.Web.HttpContext.Current.Session["UserAuthorization"];
            }
        }
    }
}