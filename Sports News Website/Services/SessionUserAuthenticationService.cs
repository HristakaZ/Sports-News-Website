using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.Services
{
    public static class SessionUserAuthenticationService
    {
        public static void SetSessionValues(AuthorizationContext filterContext)
        {
            bool UserIsNotAuthenticated = SessionService.ID == 0 && SessionService.Username == null && SessionService.IsAdmin == false;
            if (UserIsNotAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Users/Login");
            }
        }
    }
}