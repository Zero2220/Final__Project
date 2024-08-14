using Core.Entities.Categories;
using Core.Entities.Clothes;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class KazakRepository : Repository<Kazak>, IKazakRepository
    {
        public KazakRepository(FeneriumDbContext context) : base(context)
        {

        }
    }
}
