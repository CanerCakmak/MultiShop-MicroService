using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResponseProductDetailDto>> GetAllProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<ResponseProductDetailDto> GetByIdProductDetailAsync(string id);
        Task DeleteByIdProductDetailAsync(string id);
    }
}
