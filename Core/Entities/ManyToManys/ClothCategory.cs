using Core.Entities.Bases;
using Core.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ManyToManys
{
    public class ClothCategory
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int ClothId { get; set; }

        public Category Category { get; set; } 

        public ClothEntity Cloth { get; set; }
    }
}
