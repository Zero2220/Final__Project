using Core.Entities.Colors;
using Core.Entities.Gender;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(FeneriumDbContext context) : base(context)
        {

        }
    }
}
