using Sports_News_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Repositories
{
    public class UnitOfWork
    {
        private SportsNewsDBContext dbContext;
        private UserRepository userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository();
                }
                return userRepository;
            }
        }
        public UnitOfWork()
        {
            this.dbContext = new SportsNewsDBContext();
        }
    }
}