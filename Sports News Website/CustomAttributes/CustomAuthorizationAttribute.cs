using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sports_News_Website.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        Users user = new Users();
        private bool isAdmin;
        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                isAdmin = user.IsAdmin;
            }
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (IsAdmin == true)
            {
                return;
            }
            else if (IsAdmin == false)
            {
                filterContext.Result = new ViewResult { ViewName = "InsufficientPermission" };
            }
        }
    }
}