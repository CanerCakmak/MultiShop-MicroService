using MultiShop.Basket.WebApi.DTOs;

namespace MultiShop.Basket.WebApi.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasket(string userId);
        Task SaveBasket(BasketTotalDTO basket);
        Task DeleteBasket(string userId);
    }
}
