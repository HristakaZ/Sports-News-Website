using DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class NewsRepository : BaseRepository<News>
    {
        public NewsRepository(SportsNewsDBContext dbContext) : base(dbContext)
        {

        }
    }
}
