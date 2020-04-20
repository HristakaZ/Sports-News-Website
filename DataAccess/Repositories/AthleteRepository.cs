using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AthleteRepository : BaseRepository<Athletes>
    {
        public AthleteRepository(SportsNewsDBContext dbContext) : base(dbContext)
        {

        }
    }
}
