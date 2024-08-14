using Core.Entities.Clothes;
using Core.Entities.Slider;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class TShirtRepository : Repository<TShirt>, ITShirtRepository
    {
        public TShirtRepository(FeneriumDbContext context) : base(context)
        {

        }
    }
}
