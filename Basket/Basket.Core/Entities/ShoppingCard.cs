namespace Basket.Core.Entities;

public class ShoppingCard
{
    public IEnumerable<ShoppingCardItem>? ShoppingCardItems { get; set; }
    public string? Username { get; set; }

}

