using Core.Entities.ManyToManys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.AdminDtos.OtherDtos.CategoryDtos
{
    public class CategoryEditAdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IFormFile>? ImageFiles { get; set; }

    }
}
