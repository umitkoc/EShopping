using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository:IBasketRepository
{

    private readonly IDistributedCache _cache;
    public BasketRepository(IDistributedCache cache)
    {
        _cache = cache;
    }
    public async Task<ShoppingCard?> GetBasket(string username)
    {
        var basket = await _cache.GetStringAsync(username);
        return basket is not null ? JsonConvert.DeserializeObject<ShoppingCard>(basket) : null;
    }

    public async Task<ShoppingCard?> UpdateBasket(ShoppingCard shoppingCard)
    {
        await _cache.SetStringAsync(shoppingCard.Username, JsonConvert.SerializeObject(shoppingCard));
        return await GetBasket(username: shoppingCard.Username!);
    }

    public async Task RemoveBasket(string username)
    {
        await _cache.RemoveAsync(username);

    }

    public async Task<ShoppingCard> CreateBasket(ShoppingCard shoppingCard)
    {
        await _cache.SetStringAsync(shoppingCard.Username, JsonConvert.SerializeObject(shoppingCard));
        return shoppingCard;
    }
}