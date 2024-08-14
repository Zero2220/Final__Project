
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.AdminDtos.ClothesDtos.KazakDtos;
using Service.Dtos.AdminDtos.OtherDtos.CategoryDtos;
using Service.Interfaces;

namespace Final_Project.Controllers.AdminController
{

    [Route("api/[controller]")]
    [ApiController]
    public class KazakController : ControllerBase
    {
        private IKazakService _kazakService;

        public KazakController(IKazakService kazakService)
        {
            _kazakService = kazakService;
        }

        [HttpPost("Admin/Create")]
        public IActionResult Create(KazakCreateAdminDto createDto)
        {
            
            _kazakService.Create(createDto);

            return Ok();
        }

        [HttpPut("Admin/Edit")]
        public IActionResult Edit(KazakEditAdminDto kazak)
        {
            if (kazak == null)
            {
                return BadRequest();
            }
            _kazakService.Update(kazak);

            return Ok();
        }


        [HttpDelete("Admin/Remove")]
        public IActionResult Remove(int id)
        {
            
            _kazakService.Remove(id);

            return Ok();
        }

        [HttpGet("Admin/GetAll")]
        public ActionResult<List<KazakGetAdminDto>> GetAll()
        {
            List<KazakGetAdminDto> kazaks = _kazakService.GetAll();

            return Ok(kazaks);
        }

        [HttpGet("User/GetAll")]
        public ActionResult<List<KazakGetAdminDto>> GetAllUser()
        {
            List<KazakGetAdminDto> kazaks = _kazakService.GetAll();

            return Ok(kazaks);
        }

        [HttpGet("Admin/GetById")]
        public ActionResult<KazakGetAdminDto> GetById(int id)
        {
            
            return _kazakService.GetById(id);
        }

        [HttpGet("User/GetById")]
        public ActionResult<KazakGetAdminDto> GetByIdUser(int id)
        {
            
            return _kazakService.GetById(id);
        }

    }
}
