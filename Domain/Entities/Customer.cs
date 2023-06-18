using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Customer
{
    public Customer()
    {
        
    }
    public Customer(string firstName, string lastName, string address, string phone, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Phone = phone;
        Email = email;
    }

    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Required, MaxLength(50)]
    public string Address { get; set; }
    [Required, MaxLength(50)]
    public string Phone { get; set; }
    [Required, MaxLength(50)]
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
}