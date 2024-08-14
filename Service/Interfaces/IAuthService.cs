using Service.Dtos.AdminDtos.OtherDtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        string Login(AdminLoginDto loginDto);
        string Register(AdminRegisterDto registerDto);
        string ResetPassword(AdminRegisterDto registerDto);
    }
}
