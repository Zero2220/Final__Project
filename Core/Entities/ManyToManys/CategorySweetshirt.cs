using Core.Entities.Categories;
using Core.Entities.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ManyToManys
{
    public class CategorySweetshirt
    {
           public int Id { get; set; }
           public int CategoryId { get; set; }
           public int SweetshirtId { get; set; }
           public Category Category { get; set; }
           public Sweetshirt Sweetshirt { get; set; }    }
}
