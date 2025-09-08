using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResponseProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task<ResponseProductImageDto> GetByIdProductImageAsync(string id);
        Task DeleteByIdProductImageAsync(string id);
    }
}
