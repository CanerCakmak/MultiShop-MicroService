using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var Products = await _ProductService.GetAllProductsAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var Product = await _ProductService.GetByIdProductAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto Product)
        {
            if (Product == null)
            {
                return BadRequest();
            }
            await _ProductService.CreateProductAsync(Product);
            return Ok("Ürün Başarıyla Eklendi!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto Product)
        {
            if (Product == null)
            {
                return BadRequest();
            }
            var existingProduct = await _ProductService.GetByIdProductAsync(Product.ProductID);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await _ProductService.UpdateProductAsync(Product);
            return Ok("Ürün Başarıyla Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var existingProduct = await _ProductService.GetByIdProductAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await _ProductService.DeleteByIdProductAsync(id);
            return Ok("Ürün Başarıyla Silindi!");
        }
    }
}
