using Sports_News_Website.Repositories;
using Sports_News_Website.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sports_News_Website.CustomAttributes
{
    public class CustomAuthorizationAndAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        SessionUserAuthorizationService authorizedUser = new SessionUserAuthorizationService();
        SessionUserAuthorizationService authenticatedUser = new SessionUserAuthorizationService();
        public bool IsAdmin;
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            IsAdmin = authorizedUser.IsAdmin;
            if (IsAdmin == true)
            {
                return;
            }
            else if (IsAdmin == false)
            {
                filterContext.Result = new ViewResult { ViewName = "InsufficientPermission" };
            }
            if (authenticatedUser.ID == 0 && authenticatedUser.Username == null)
            {
                filterContext.Result = new ViewResult { ViewName = "Login" };
            }
            else if(authenticatedUser.ID != 0 && authenticatedUser.Username != null)
            {
                return;
            }
        }
    }
}