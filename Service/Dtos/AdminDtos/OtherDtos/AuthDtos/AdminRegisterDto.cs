using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.AdminDtos.OtherDtos.AuthDtos
{
    public class AdminRegisterDto
    {
        public int Username { get; set; } 
        public int Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? NewPassword { get; set; }
    }
}
