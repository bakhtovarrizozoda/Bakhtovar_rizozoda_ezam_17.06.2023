namespace Domain.Entities;

public class GetOrderDetailDto : OrderDetailBaseDto
{
    public string Products { get; set; }
    public DateTime Orders { get; set; }
}