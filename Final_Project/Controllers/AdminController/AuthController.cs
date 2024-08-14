using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.AdminDtos.OtherDtos.AuthDtos;
using Service.Interfaces;

namespace Final_Project.Controllers.AdminController
{

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IAuthService authService, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _authService = authService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("Register")]
        public async Task<IActionResult> CreateUser()
        {

            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Member"));


            AppUser user1 = new AppUser
            {
                FullName = "Admin",
                UserName = "admin",
            };

            await _userManager.CreateAsync(user1, "Admin123");

            AppUser user2 = new AppUser
            {
                FullName = "Member",
                UserName = "member",
            };

            await _userManager.CreateAsync(user2, "Member123");

            await _userManager.AddToRoleAsync(user1, "Admin");
            await _userManager.AddToRoleAsync(user2, "Member");

            return Ok(user1.Id);
        }


        [HttpPost("login")]
        public ActionResult Login(AdminLoginDto loginDto)
        {
            var token = _authService.Login(loginDto);
            return Ok(new { token });
        }


        [Authorize]
        [HttpGet("profile")]
        public ActionResult Profile()
        {
            return Ok(User.Identity.Name);
        }
    }

}
