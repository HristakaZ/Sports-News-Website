using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CommentRepository : BaseRepository<Comments>
    {
        public CommentRepository(SportsNewsDBContext dbContext) : base(dbContext)
        {

        }
    }
}
