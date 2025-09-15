using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var category = await _categoryService.GetByIdCategoryAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            await _categoryService.CreateCategoryAsync(category);
            return Ok("Kategori Başarıyla Eklendi!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            var existingCategory = await _categoryService.GetByIdCategoryAsync(category.CategoryID);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryService.UpdateCategoryAsync(category);
            return Ok("Kategori Başarıyla Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var existingCategory = await _categoryService.GetByIdCategoryAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryService.DeleteByIdCategoryAsync(id);
            return Ok("Kategori Başarıyla Silindi!");
        }
    }
}
