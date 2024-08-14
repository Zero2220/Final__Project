using AutoMapper;
using Core.Entities.Categories;
using Core.Entities.Slider;
using Service.Dtos.AdminDtos.OtherDtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Entities.Clothes;
using Service.Dtos.AdminDtos.ClothesDtos.KazakDtos;

namespace Service.Profiles
{
    public class MappingProfile : Profile
    {
        private readonly IHttpContextAccessor _context;

        public MappingProfile(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;

            var uriBuilder = new UriBuilder(
                _context.HttpContext.Request.Scheme,
                _context.HttpContext.Request.Host.Host,
                _context.HttpContext.Request.Host.Port ?? -1
            );
            string baseUrl = uriBuilder.Uri.AbsoluteUri;

            CreateMap<CategoryCreateAdminDto, Category>().ReverseMap();
            CreateMap<Category, CategoryGetAdminDto>().ReverseMap();
            CreateMap<CategoryEditAdminDto, Category>().ReverseMap();

            

            CreateMap<Kazak, KazakGetAdminDto>()
          .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(src => src.CategoryKazaks.Select(c => c.CategoryId)));

            CreateMap<KazakEditAdminDto, Kazak>();
            CreateMap<KazakCreateAdminDto, Kazak>();
        }
    }
}
