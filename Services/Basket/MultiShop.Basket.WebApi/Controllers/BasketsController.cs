using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.WebApi.DTOs;
using MultiShop.Basket.WebApi.LoginServices;
using MultiShop.Basket.WebApi.Services;

namespace MultiShop.Basket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var user = User.Claims;
            var userId = _loginService.GetUserID;

            if (!_loginService.IsUserValid(userId))
                return BadRequest("User not found");

            var basket = await _basketService.GetBasket(userId);
            if (basket == null)
                return NotFound();

            return Ok(basket);
        }
        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDTO basket)
        {
            var userId = _loginService.GetUserID;

            if (!_loginService.IsUserValid(userId))
                return BadRequest("User not found");

            basket.UserID = userId;

            await _basketService.SaveBasket(basket);
            return Ok("Sepetteki değişiklikler kaydedildi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = _loginService.GetUserID;

            if (!_loginService.IsUserValid(userId))
                return BadRequest("User not found");

            await _basketService.DeleteBasket(userId);
            return Ok("Sepet başarıyla silindi.");
        }
    }
}
