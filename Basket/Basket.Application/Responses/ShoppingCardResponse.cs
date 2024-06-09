namespace Basket.Application.Responses;

public class ShoppingCardResponse
{
    public string? Username { get; set; }
    public IEnumerable<ShoppingCardItemResponse>? ShoppingCardItems { get; set; }


    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in ShoppingCardItems!)
            {
                totalPrice += item.Price * item.Quantity;
            }

            return totalPrice;
        }
    }

}