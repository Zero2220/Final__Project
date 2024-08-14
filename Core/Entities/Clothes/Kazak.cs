using Core.Entities.Bases;
using Core.Entities.Genders;
using Core.Entities.ManyToManys;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Clothes
{
    public class Kazak : ClothesEntity
    {
        
        public List<CategoryKazak> CategoryKazaks { get; set; }
    }
}
