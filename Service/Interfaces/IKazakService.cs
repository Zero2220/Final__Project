using Service.Dtos.AdminDtos.ClothesDtos.KazakDtos;
using Service.Dtos.AdminDtos.OtherDtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IKazakService
    {
        public int Create(KazakCreateAdminDto kazakCreateAdminDto);
        public void Update(KazakEditAdminDto kazakEditAdminDto);
        public void Remove(int id);
        public List<KazakGetAdminDto> GetAll();
        public KazakGetAdminDto GetById(int id);
    }
}
