using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository<Users>
    {
        public UserRepository(SportsNewsDBContext dbContext) : base(dbContext)
        {

        }
    }
}
