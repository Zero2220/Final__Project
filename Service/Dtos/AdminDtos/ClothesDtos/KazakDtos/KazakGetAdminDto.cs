using Core.Entities.ManyToManys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.AdminDtos.ClothesDtos.KazakDtos
{
    public class KazakGetAdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public string ProductId { get; set; }
        public List<int> Likes { get; set; } = new List<int>();
        public List<string> ImageNames { get; set; } = new List<string>();
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
