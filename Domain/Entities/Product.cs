using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product
{
    public Product()
    {
        
    }
    public Product(string modelName, decimal modelPrice)
    {
        Name = modelName;
        Price = modelPrice;
    }

    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}