using Discount.Core.Entities;

namespace Discount.Core.Repositories;

public interface IDiscountRepo
{
    Task<Coupon> GetDiscount(string productName);
    Task<Coupon> CreateDiscount(Coupon coupon);
    Task<bool> RemoveDiscount(string productName);
    Task<bool> UpdateDiscount(Coupon coupon);
}