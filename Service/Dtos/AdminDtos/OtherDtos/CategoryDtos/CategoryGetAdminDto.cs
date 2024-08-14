using Core.Entities.ManyToManys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.AdminDtos.OtherDtos.CategoryDtos
{
    public class CategoryGetAdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ImageName { get; set; }
        

    }
}
