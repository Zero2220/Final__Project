using Core.Entities.Clothes;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class MayoRepository : Repository<Mayo>, IMayoRepository
    {
        public MayoRepository(FeneriumDbContext context) : base(context)
        {

        }
    }
}
