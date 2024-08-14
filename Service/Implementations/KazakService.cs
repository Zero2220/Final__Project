using AutoMapper;
using Core.Entities.Categories;
using Core.Entities.Clothes;
using Core.Entities.ManyToManys;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using Service.Dtos.AdminDtos.ClothesDtos.KazakDtos;
using Service.Dtos.AdminDtos.OtherDtos.CategoryDtos;
using Service.Extensions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class KazakService : IKazakService
    {
        private readonly IKazakRepository _kazakRepository;
        private readonly IMapper _mapper;

        public KazakService(IKazakRepository kazak, IMapper autoMapper)
        {
            _mapper = autoMapper;
            _kazakRepository = kazak;
        }

        public int Create(KazakCreateAdminDto createDto)
        {
            if (createDto == null) throw new ArgumentNullException(nameof(createDto));

            if (_kazakRepository.Exists(x => x.IsDeleted! && x.Name == createDto.Name))
            {
                throw new ArgumentException();
            }
            Kazak kazak = _mapper.Map<Kazak>(createDto);

            if (createDto.ImageFiles == null)
            {
                throw new ArgumentException("Image files cannot be null.");
            }

            kazak.ImageNames = new List<string>();

            foreach (var item in createDto.ImageFiles)
            {
                string image = item.Save("uploads/kazaks");
                kazak.ImageNames.Add(image);
            }
            if (createDto.CategoryIds != null && createDto.CategoryIds.Any())
            {
                kazak.CategoryKazaks = new List<CategoryKazak>();
                foreach (var categoryId in createDto.CategoryIds)
                {
                    kazak.CategoryKazaks.Add(new CategoryKazak
                    {
                        CategoryId = categoryId,
                        Kazak = kazak
                    });
                }
            }
            _kazakRepository.Add(kazak);
            _kazakRepository.Save();
            return kazak.Id;
        }

        public void Update(KazakEditAdminDto editDto)
        {
            if (editDto == null) throw new ArgumentNullException(nameof(editDto));

            if (_kazakRepository.Exists(x => x.IsDeleted && x.Name == editDto.Name))
            {
                throw new ArgumentException("Kazak with the same name already exists.");
            }

            Kazak kazak = _kazakRepository.Get(x => x.Id == editDto.Id && !x.IsDeleted);
            if (kazak == null) throw new ArgumentException("Kazak not found.");

            kazak.Name = editDto.Name;
            kazak.Price = editDto.Price;
            kazak.DiscountPercent = editDto.DiscountPercent;
            kazak.ProductId = editDto.ProductId;
            kazak.ModifiedAt = DateTime.Now;

            if (editDto.ImageFiles == null || !editDto.ImageFiles.Any())
            {
                throw new ArgumentException("Image files cannot be null.");
            }

            kazak.ImageNames = new List<string>();
            foreach (var item in editDto.ImageFiles)
            {
                string image = item.Save("uploads/kazaks");
                kazak.ImageNames.Add(image);
            }

            if (editDto.CategoryIds != null && editDto.CategoryIds.Any())
            {
                kazak.CategoryKazaks.Clear();

                foreach (var categoryId in editDto.CategoryIds)
                {
                    kazak.CategoryKazaks.Add(new CategoryKazak
                    {
                        CategoryId = categoryId,
                        KazakId = kazak.Id
                    });
                }
            }

            _kazakRepository.Save();
        }


        public void Remove(int id)
        {
            if (id == null) throw new ArgumentNullException();

            Kazak kazak = _kazakRepository.Get(x => x.Id == id);

            kazak.ModifiedAt = DateTime.UtcNow;

            kazak.IsDeleted = true;

            _kazakRepository.Save();
        }

        public List<KazakGetAdminDto> GetAll()
        {
            return _mapper.Map<List<KazakGetAdminDto>>(_kazakRepository.GetAll(x => !x.IsDeleted).ToList());
        }

        public KazakGetAdminDto GetById(int id)
        {
            if (id <= 0) throw new ArgumentNullException(nameof(id));

            Kazak kazak = _kazakRepository.Get(x => x.Id == id && !x.IsDeleted);
            if (kazak == null) throw new ArgumentException("Kazak not found.");


            return _mapper.Map<KazakGetAdminDto>(kazak);
        }
    }
}
