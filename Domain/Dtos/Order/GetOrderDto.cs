namespace Domain.Entities;

public class GetOrderDto : OrderBaseDto
{
    public string Customers { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}