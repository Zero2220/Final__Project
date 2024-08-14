using Core.Entities.Colors;
using Core.Entities.Genders;
using Core.Entities.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Bases
{
    public class ClothesEntity:AuditEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ProductId { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Color> Colors { get; set; }
        public List<Gender> Genders { get; set; }
        public List<int>? Likes { get; set; }
        public List<string> ImageNames { get; set; }
    }
}
