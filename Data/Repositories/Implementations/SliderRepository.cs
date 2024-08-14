using Core.Entities.Categories;
using Core.Entities.Slider;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(FeneriumDbContext context) : base(context)
        {

        }
    }
}
