using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Sports_News_Website.Services
{
    public static class SessionUserAuthorizationService
    {
        //make bool variables that have the values of the conditions (for each if make a variable)
        public static void SetSessionValues(AuthorizationContext filterContext)
        {
            bool UserIsNotAdmin = SessionService.ID != 0 && SessionService.Username != null && SessionService.IsAdmin == false;
            if (UserIsNotAdmin)
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