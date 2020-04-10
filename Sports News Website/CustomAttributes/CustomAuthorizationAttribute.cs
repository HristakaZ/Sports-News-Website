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
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        SessionUserService sessionUserService = new SessionUserService();
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (sessionUserService.IsAdmin)
            {
                return;
            }
            else if (!sessionUserService.IsAdmin)
            {
                filterContext.Result = new ViewResult { ViewName = "InsufficientPermission" };
            }
        }
    }
}