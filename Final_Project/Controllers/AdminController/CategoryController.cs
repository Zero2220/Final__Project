using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Dtos.AdminDtos.OtherDtos.CategoryDtos;
using Service.Interfaces;

namespace Final_Project.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("Admin/Create")]
        public IActionResult Create(CategoryCreateAdminDto createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            _categoryService.Create(createDto);

            return Ok();
        }

        [HttpPut("Admin/Edit")]
        public IActionResult Edit(CategoryEditAdminDto editDto)
        {
            if (editDto == null)
            {
                return BadRequest();
            }
            _categoryService.Update(editDto);

            return Ok();
        }

      
        [HttpDelete("Admin/Remove")]
        public IActionResult Remove(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _categoryService.Remove(id);

            return Ok();
        }

        [HttpGet("Admin/GetAll")]
        public ActionResult<PaginatedList<CategoryGetAdminDto>> GetAll(string? search = null, int page = 1, int size = 10)
        {
            return StatusCode(200, _categoryService.GetAllByPage(search, page, size));
        }

        [HttpGet("User/GetAll")]
        public ActionResult<List<CategoryGetAdminDto>> GetAllUser()
        {
            List<CategoryGetAdminDto> categories = _categoryService.GetAll();

            return Ok(categories);
        }

        [HttpGet("Admin/GetById")]
        public ActionResult<CategoryGetAdminDto> GetById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            return _categoryService.GetById(id);
        }

        [HttpGet("User/GetById")]
        public ActionResult<CategoryGetAdminDto> GetByIdUser(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            return _categoryService.GetById(id);
        }

    }
}
