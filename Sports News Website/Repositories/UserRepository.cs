using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Repositories
{
    public class UserRepository : BaseRepository<Users>
    {
        public SportsNewsDBContext dbContext = new SportsNewsDBContext();
        public Users GetUserByID(int id)
        {
            Users user = new Users();
            user = dbContext.Users.Find(id);
            return user;
        }
    }
}