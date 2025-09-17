using MultiShop.Basket.WebApi.DTOs;
using MultiShop.Basket.WebApi.Settings;
using System.Text.Json;

namespace MultiShop.Basket.WebApi.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDB().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDTO> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDB().StringGetAsync(userId);
            return existBasket.HasValue ? JsonSerializer.Deserialize<BasketTotalDTO>(existBasket) : null;
        }

        public async Task SaveBasket(BasketTotalDTO basket)
        {
            await _redisService.GetDB().StringSetAsync(basket.UserID, JsonSerializer.Serialize(basket));
        }
    }
}
