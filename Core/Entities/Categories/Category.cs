using Core.Entities.Bases;
using Core.Entities.ManyToManys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Categories
{
    public class Category : AuditEntity
    {
        public string Name { get; set; }
        public List<string> ImageName { get; set; }
        public List<CategoryKazak>? CategoryKazaks { get; set; }
        public List<CategoryMayo>? CategoryMayos { get; set; }
        public List<CategoryShirt>? CategoryShirts { get; set; }
        public List<CategoryShorts>? CategoryShorts { get; set; }
        public List<CategorySocks>? CategorySocks { get; set; }
        public List<CategorySweetshirt>? CategorySweetshirts { get; set; }
        public List<CategoryTshirt>? CategoryTshirts { get; set; }

    }
}
