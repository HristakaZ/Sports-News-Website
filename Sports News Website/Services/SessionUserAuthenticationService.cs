using Sports_News_Website.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Services
{
    public class SessionUserAuthenticationService
    {
        public void SetSessionValues(AuthorizationContext filterContext)
        {
            bool UserIsNotAuthenticated = SessionDTO.ID == 0 &&
                SessionDTO.Username == null
                && SessionDTO.IsAdmin == false;
            if (UserIsNotAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Users/Login");
            }
        }
    }
}