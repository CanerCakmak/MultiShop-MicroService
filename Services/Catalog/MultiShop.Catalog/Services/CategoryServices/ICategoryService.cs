using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResponseCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<ResponseCategoryDto> GetByIdCategoryAsync(string id);
        Task DeleteByIdCategoryAsync(string id);
    }
}
