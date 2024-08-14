using Core.Entities.Clothes;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class ShirtRepository : Repository<Shirt>, IShirtRepository
    {
        public ShirtRepository(FeneriumDbContext context) : base(context)
        {

        }
    }
}
