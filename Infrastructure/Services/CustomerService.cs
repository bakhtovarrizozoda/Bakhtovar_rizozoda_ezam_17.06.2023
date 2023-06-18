using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CustomerService
{
    private readonly DataContext _context;

    public CustomerService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerBaseDto>> GetCustomer()
    {
        return await _context.Customers.Select(e=>new CustomerBaseDto()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Address = e.Address,
            Phone = e.Phone,
            Email = e.Email
        }).ToListAsync();
    }

    public async Task<CustomerBaseDto?> GetCustomerByName(string name)
    {
        return await _context.Customers.Select(e => new CustomerBaseDto()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Address = e.Address,
            Phone = e.Phone,
            Email = e.Email
        }).FirstOrDefaultAsync(p => p.FirstName == name);
    }
    
    public async Task<CustomerBaseDto?> GetCustomerById(int id)
    {
        return await _context.Customers.Select(e => new CustomerBaseDto()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Address = e.Address,
            Phone = e.Phone,
            Email = e.Email
        }).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<CustomerBaseDto> AddCustomer(CustomerBaseDto model)
    {
        var cust = new Customer(model.FirstName, model.LastName, model.Address, model.Phone, model.Email);
        await _context.Customers.AddAsync(cust);
        await _context.SaveChangesAsync();
        model.Id = cust.Id;
        return model;
    }

    public async Task<CustomerBaseDto> UpdateCustomer(CustomerBaseDto model)
    {
        var find = await _context.Customers.FindAsync(model.Id);
        find.Id = model.Id;
        find.FirstName = model.FirstName;
        find.LastName = model.LastName;
        find.Address = model.Address;
        find.Phone = model.Phone;
        find.Email = model.Email;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        var find = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}