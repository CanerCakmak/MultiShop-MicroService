using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResponseProductDto>> GetAllProductsAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ResponseProductDto> GetByIdProductAsync(string id);
        Task DeleteByIdProductAsync(string id);
    }
}
