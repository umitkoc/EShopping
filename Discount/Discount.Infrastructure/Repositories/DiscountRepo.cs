using Discount.Core.Entities;
using Discount.Core.Repositories;

namespace Discount.Infrastructure.Repositories;

public class DiscountRepo:IDiscountRepo
{
    public DiscountRepo()
    {
        
    }
    public Task<Coupon> GetDiscount(string productName)
    {
        throw new NotImplementedException();
    }

    public Task<Coupon> CreateDiscount(Coupon coupon)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveDiscount(string productName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateDiscount(Coupon coupon)
    {
        throw new NotImplementedException();
    }
}