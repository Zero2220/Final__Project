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
        public string ImageName { get; set; }
        public List<ClothCategory> ClothCategories { get; set; }
    }
}
