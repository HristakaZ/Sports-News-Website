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
        public bool IsAdmin;
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            IsAdmin = SessionService.IsAdmin;
            authorizedUser.SetSessionValues(filterContext);
        }
    }
}