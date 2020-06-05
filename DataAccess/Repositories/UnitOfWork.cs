using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork
    {
        private SportsNewsDBContext dbContext;
        private UserRepository userRepository;
        private NewsRepository newsRepository;
        private SportRepository sportRepository;
        private AthleteRepository athleteRepository;
        private CommentRepository commentRepository;
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

        public SportRepository SportRepository
        {
            get
            {
                if (this.sportRepository == null)
                {
                    this.sportRepository = new SportRepository(dbContext);
                }
                return sportRepository;
            }
        }

        public AthleteRepository AthleteRepository
        {
            get
            {
                if (this.athleteRepository == null)
                {
                    this.athleteRepository = new AthleteRepository(dbContext);
                }
                return athleteRepository;
            }
        }

        public CommentRepository CommentRepository
        {
            get
            {
                if (this.commentRepository == null)
                {
                    this.commentRepository = new CommentRepository(dbContext);
                }
                return commentRepository;
            }
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        private UnitOfWork()
        {
            this.dbContext = new SportsNewsDBContext();
        }
    }
}
