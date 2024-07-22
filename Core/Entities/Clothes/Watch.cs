using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Clothes
{
    public class Watch
    {
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ProductId { get; set; }
        public List<int> Likes { get; set; }
    }
}
