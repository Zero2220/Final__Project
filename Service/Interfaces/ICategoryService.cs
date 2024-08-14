using Service.Dtos;
using Service.Dtos.AdminDtos.OtherDtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
            public int Create(CategoryCreateAdminDto categoryCreateDto);
            public void Update(CategoryEditAdminDto editDto);
            public void Remove(int id);
            public List<CategoryGetAdminDto> GetAll();
            public PaginatedList<CategoryGetAdminDto> GetAllByPage(string? search = null, int page = 1, int size = 10);
            public CategoryGetAdminDto GetById(int id);
        
    }
}
