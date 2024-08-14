using Core.Entities.Clothes;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class ShortsRepository : Repository<Shorts>, IShortsRepository
    {
        public ShortsRepository(FeneriumDbContext context) : base(context)
        {

        }
    }
}
