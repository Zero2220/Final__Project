using AutoMapper;
using Core.Entities.Categories;
using Core.Entities.Slider;
using Data.Repositories.Interfaces;
using Service.Dtos;
using Service.Dtos.AdminDtos.OtherDtos.CategoryDtos;
using Service.Extensions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository category, IMapper autoMapper)
        {
            _mapper = autoMapper;
            _categoryRepository = category;
        }

        public int Create(CategoryCreateAdminDto createDto)
        {
            if (createDto == null) throw new ArgumentNullException();

            if (_categoryRepository.Exists(x => x.IsDeleted! && x.Name == createDto.Name))
            {
                throw new ArgumentException();
            }
            Category category = _mapper.Map<CategoryCreateAdminDto, Category>(createDto);

            if (createDto.ImageFiles == null)
            {
                throw new ArgumentException("Image files cannot be null.");
            }

            int count = 0;

            category.ImageName = new List<string>();


            foreach (var item in createDto.ImageFiles)
            {

                string image = item.Save("uploads/categories");
                category.ImageName.Add(image);
                count++;
            }

            _categoryRepository.Add(category);
            _categoryRepository.Save();
            return category.Id;
        }
        public void Update(CategoryEditAdminDto editDto)
        {
            if (editDto == null) throw new ArgumentNullException();

            if (_categoryRepository.Exists(x => x.IsDeleted! && x.Name == editDto.Name)) { throw new ArgumentException(); }

            Category category = _categoryRepository.Get(x => x.Id == editDto.Id && !x.IsDeleted);

            if (editDto.ImageFiles == null)
            {
                throw new ArgumentException("Image files cannot be null.");
            }

            category.ImageName = new List<string>();

            category.Name = editDto.Name;
            category.ModifiedAt = DateTime.Now;
            int count = 0;
            foreach (var item in editDto.ImageFiles)
            {
                string image = item.Save("uploads/categories");
                category.ImageName.Add(image);
                count++;
            }

            category.ModifiedAt = DateTime.Now;

            category.Name = editDto.Name;

            _categoryRepository.Save();

        }

        public void Remove(int id)
        {
            if (id == null) throw new ArgumentNullException();

            Category category = _categoryRepository.Get(x => x.Id == id);

            category.ModifiedAt = DateTime.UtcNow;

            category.IsDeleted = true;

            _categoryRepository.Save();
        }

        public List<CategoryGetAdminDto> GetAll()
        {
            return _mapper.Map<List<CategoryGetAdminDto>>(_categoryRepository.GetAll(x => !x.IsDeleted).ToList());
        }

        public PaginatedList<CategoryGetAdminDto> GetAllByPage(string? search = null, int page = 1, int size = 10)
        {
            var query = _categoryRepository.GetAll(x => !x.IsDeleted && (search == null));
            var paginated = PaginatedList<Category>.Create(query, page, size);
            return new PaginatedList<CategoryGetAdminDto>(_mapper.Map<List<CategoryGetAdminDto>>(paginated.Items), paginated.TotalPages, page, size);
        }


        public CategoryGetAdminDto GetById(int id)
        {
            Category category = _categoryRepository.Get(x => x.Id == id && !x.IsDeleted);

            CategoryGetAdminDto dto = _mapper.Map<Category, CategoryGetAdminDto>(category);

            return dto;
        }
    }
}

