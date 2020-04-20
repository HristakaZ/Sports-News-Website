using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SportRepository : BaseRepository<Sports>
    {
        public SportRepository(SportsNewsDBContext dbContext) : base(dbContext)
        {

        }
    }
}
