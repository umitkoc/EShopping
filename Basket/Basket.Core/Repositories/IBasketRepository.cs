using Basket.Core.Entities;

namespace Basket.Core.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCard?> GetBasket(string username);
    Task<ShoppingCard?> UpdateBasket(ShoppingCard shoppingCard);
    Task RemoveBasket(string username);

    Task<ShoppingCard> CreateBasket(ShoppingCard shoppingCard);
}