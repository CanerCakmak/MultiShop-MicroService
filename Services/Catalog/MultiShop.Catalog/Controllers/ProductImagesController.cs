using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImages()
        {
            var ProductImages = await _ProductImageService.GetAllProductImagesAsync();
            return Ok(ProductImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var ProductImage = await _ProductImageService.GetByIdProductImageAsync(id);
            if (ProductImage == null)
            {
                return NotFound();
            }
            return Ok(ProductImage);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto ProductImage)
        {
            if (ProductImage == null)
            {
                return BadRequest();
            }
            await _ProductImageService.CreateProductImageAsync(ProductImage);
            return Ok("Ürün Resmi Başarıyla Eklendi!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto ProductImage)
        {
            if (ProductImage == null)
            {
                return BadRequest();
            }
            var existingProductImage = await _ProductImageService.GetByIdProductImageAsync(ProductImage.ProductImageID);
            if (existingProductImage == null)
            {
                return NotFound();
            }
            await _ProductImageService.UpdateProductImageAsync(ProductImage);
            return Ok("Ürün Resmi Başarıyla Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var existingProductImage = await _ProductImageService.GetByIdProductImageAsync(id);
            if (existingProductImage == null)
            {
                return NotFound();
            }
            await _ProductImageService.DeleteByIdProductImageAsync(id);
            return Ok("Ürün Resmi Başarıyla Silindi!");
        }
    }
}
