using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sports_News_Website.CustomAttributes;
using Sports_News_Website.Models;
using Sports_News_Website.Repositories;

namespace Sports_News_Website.Controllers
{
    public class NewsController : BaseRepository<News>
    {
        
    }
}