using Core.Entities.Categories;
using Core.Entities.ManyToManys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Bases
{
    public class ClothEntity : AuditEntity
    {
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ProductId { get; set; }
        public List<int> Likes { get; set; }
        public List<ClothCategory> ClothCategories { get; set; }
    }
}
