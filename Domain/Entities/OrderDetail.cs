using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }
    public Product Products { get; set; }
    public Order Orders { get; set; }
}