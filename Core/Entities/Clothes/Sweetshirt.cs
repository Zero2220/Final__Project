﻿using Core.Entities.Bases;
using Core.Entities.ManyToManys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Clothes
{
    public class Sweetshirt : ClothesEntity
    {
        public List<CategorySweetshirt> CategorySweetshirts { get; set; }
    }
}
