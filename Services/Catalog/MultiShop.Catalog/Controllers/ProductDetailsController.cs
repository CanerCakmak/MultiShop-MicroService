using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var ProductDetails = await _ProductDetailService.GetAllProductDetailsAsync();
            return Ok(ProductDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var ProductDetail = await _ProductDetailService.GetByIdProductDetailAsync(id);
            if (ProductDetail == null)
            {
                return NotFound();
            }
            return Ok(ProductDetail);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto ProductDetail)
        {
            if (ProductDetail == null)
            {
                return BadRequest();
            }
            await _ProductDetailService.CreateProductDetailAsync(ProductDetail);
            return Ok("Ürün Detayı Başarıyla Eklendi!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto ProductDetail)
        {
            if (ProductDetail == null)
            {
                return BadRequest();
            }
            var existingProductDetail = await _ProductDetailService.GetByIdProductDetailAsync(ProductDetail.ProductDetailID);
            if (existingProductDetail == null)
            {
                return NotFound();
            }
            await _ProductDetailService.UpdateProductDetailAsync(ProductDetail);
            return Ok("Ürün Detayı Başarıyla Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            var existingProductDetail = await _ProductDetailService.GetByIdProductDetailAsync(id);
            if (existingProductDetail == null)
            {
                return NotFound();
            }
            await _ProductDetailService.DeleteByIdProductDetailAsync(id);
            return Ok("Ürün Detayı Başarıyla Silindi!");
        }
    }
}
