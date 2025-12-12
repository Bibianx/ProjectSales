using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Response;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CategoriesController(ICategoriesServices categoriesServices) : ControllerBase
    {
        private readonly ICategoriesServices _categoriesServices = categoriesServices;

        [HttpGet("get-category-by-id/{categoryId}")]
        public async Task<ActionResult<ServiceResponse<CategoriesResponse>>> GetCategoryById(Guid categoryId)
        {
            return await _categoriesServices.GetCategoryById(categoryId);
        }

        [HttpGet("get-all-categories")]
        public async Task<ActionResult<ServiceResponse<List<CategoriesResponse>>>> GetAllCategories()
        {
            return await _categoriesServices.GetAllCategories();
        }
        [HttpPost("create-category")]
        public async Task<ActionResult<ServiceResponse<CategoriesResponse>>> CreateCategory([FromBody] CategoriesRequest data)
        {
            return await _categoriesServices.CreateCategory(data);
        }
        [HttpPut("edit-category")]
        public async Task<ActionResult<ServiceResponse<CategoriesResponse>>> EditCategory([FromBody] CategoriesRequest data)
        {
            return await _categoriesServices.EditCategory(data);
        }
    }
}