using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Repositories
{
    public class CommentRepository : BaseRepository<Comments>
    {
        public CommentRepository(SportsNewsDBContext dbContext) : base(dbContext)
        {

        }
    }
}