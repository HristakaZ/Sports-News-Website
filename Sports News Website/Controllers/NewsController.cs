using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sports_News_Website.CustomAttributes;
using Sports_News_Website.Models;

namespace Sports_News_Website.Controllers
{
    [CustomAuthorizationAttribute(IsAdmin = true)]
    public class NewsController : BaseController<News>
    {
        
    }
}