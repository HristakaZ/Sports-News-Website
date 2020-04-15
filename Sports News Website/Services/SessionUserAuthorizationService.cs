using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Sports_News_Website.Services
{
    public class SessionUserAuthorizationService
    {
        public SessionUserAuthorizationService()
        {
            AuthorizationContext filterContext = new AuthorizationContext(); // probably should remove this line
            SetSessionValues(filterContext);
        }
        //make bool variables that have the values of the conditions (for each if make a variable)
        public void SetSessionValues(AuthorizationContext filterContext)
        {
            if (SessionService.ID == 0 && SessionService.Username == null && SessionService.IsAdmin == false)
            {
                filterContext.Result = new RedirectResult("~/Users/Login");
            }
            else if (SessionService.ID != 0 && SessionService.Username != null && SessionService.IsAdmin == false)
            {
                filterContext.Result = new RedirectResult("~/News/Read");
            }
            if (SessionService.IsAdmin == false && SessionService.ID != 0 && SessionService.Username != null)
            {
                filterContext.Result = new ViewResult { ViewName = "InsufficientPermission" };
            }
            else
            {
                return;
            }
        }
    }
}