namespace Discount.Core.Entities;

public class Coupon
{
    public string? Id { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
}