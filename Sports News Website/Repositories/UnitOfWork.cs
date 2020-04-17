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
        private NewsRepository newsRepository;
        private static UnitOfWork uow;
        public static UnitOfWork UOW
        {
            get
            {
                if (uow == null)
                {
                    uow = new UnitOfWork();
                }
                return uow;
            }
        }
        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(dbContext);
                }
                return userRepository;
            }
        }
        public NewsRepository NewsRepository
        {
            get
            {
                if (this.newsRepository == null)
                {
                    this.newsRepository = new NewsRepository(dbContext);
                }
                return newsRepository;
            }
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public UnitOfWork()
        {
            this.dbContext = new SportsNewsDBContext();
        }
    }
}