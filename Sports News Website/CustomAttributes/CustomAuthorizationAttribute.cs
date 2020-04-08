using Sports_News_Website.Repositories;
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
        SessionUserRepository sessionUserRepository = new SessionUserRepository();
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (sessionUserRepository.IsAdmin)
            {
                return;
            }
            else if (!sessionUserRepository.IsAdmin)
            {
                filterContext.Result = new ViewResult { ViewName = "InsufficientPermission" };
            }
        }
    }
}