using Microsoft.AspNetCore.Mvc;
using UI.Exceptions;
using UI.Filters;
using UI.Models.Categories;
using UI.Services.Interfaces;

namespace UI.Controllers
{

        [ServiceFilter(typeof(AuthFilter))]
        public class CategoryController : Controller
        {
            private HttpClient _client;
            private readonly ICrudService _crudService;
            private readonly string ImageUrl = "https://localhost:7127/uploads/categories/";

            public CategoryController(ICrudService crudService)
            {
                _client = new HttpClient();
                _crudService = crudService;
            }

            public async Task<IActionResult> Index(int page = 1)
            {
                try
                {
                    
                return View(await _crudService.GetAllPaginated<CategoryListItemDetailedGetResponse>("Category/Admin/GetAll", page));
                }
                catch (HttpException e)
                {
                    if (e.Status == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("login", "auth");
                    }
                    else return RedirectToAction("error", "home");
                }
                catch (Exception e)
                {
                    return RedirectToAction("error", "home");
                }
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(CategoryCreateRequest createRequest)
            {
                if (!ModelState.IsValid) return View();

                try
                {
                    await _crudService.CreateFromForm<CategoryCreateRequest>(createRequest, "Category/Admin/Create");
                    return RedirectToAction("index");
                }
                catch (ModelException e)
                {
                    foreach (var item in e.Error.Errors) ModelState.AddModelError(item.Key, item.Message);
                    return View();
                }
            }

            public async Task<IActionResult> Edit(int id)
            {
                 CategoryListItemDetailedGetResponse GetCategory = await _crudService.Get<CategoryListItemDetailedGetResponse>("Category/Admin/GetById?id=" + id);

               CategoryEditRequest editRequest = new CategoryEditRequest();

                editRequest.Id=id;

                editRequest.Name = GetCategory.Name;

                List<string> imageUrls = new List<string>();

              foreach(var item in GetCategory.ImageName)
              {
                imageUrls.Add(ImageUrl + item);
              }
                ViewBag.ImageUrls = imageUrls;
            
                 return View(editRequest);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(CategoryEditRequest editRequest)
            {
                if (!ModelState.IsValid) return View();

                try
                {
                
                    await _crudService.UpdateFromForm<CategoryEditRequest>(editRequest, "Category/Admin/Edit");
                    return RedirectToAction("index");
                }
                catch (ModelException e)
                {
                    foreach (var item in e.Error.Errors)
                        ModelState.AddModelError(item.Key, item.Message);

                    return View();
                }
            }

            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    await _crudService.Delete("Category/" + id);
                    return Ok();
                }
                catch (HttpException e)
                {
                    return StatusCode((int)e.Status);
                }
            }
        }

    
}
