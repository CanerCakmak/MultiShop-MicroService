using MultiShop.Discount.Dtos.CouponDtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResponseDiscountCouponDto>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<ResponseDiscountCouponDto> GetDiscountCouponByIdAsync(int id);

    }
}
