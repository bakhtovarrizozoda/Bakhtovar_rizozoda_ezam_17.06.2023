using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Order
{
    public Order()
    {
        
    }
    public Order(DateTime modelOrderPlaced, DateTime modelOrderFulFilled, int modelCustomerId)
    {
        OrderPlaced = modelOrderPlaced;
        OrderFulFilled = modelOrderFulFilled;
        CustomerId = modelCustomerId;
    }

    public int Id { get; set; }
    [Required]
    public DateTime OrderPlaced { get; set; }
    [Required]
    public DateTime OrderFulFilled { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer Customers { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}