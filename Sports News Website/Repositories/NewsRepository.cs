﻿using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Repositories
{
    public class NewsRepository : BaseRepository<News>
    {
        public NewsRepository(SportsNewsDBContext dbContext) : base(dbContext)
        {

        }
    }
}