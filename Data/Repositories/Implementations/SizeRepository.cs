using Core.Entities.Clothes;
using Core.Entities.Sizes;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        public SizeRepository(FeneriumDbContext context) : base(context)
        {

        }
    }
}
