using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class OrderService
{
    private readonly DataContext _context;

    public OrderService(DataContext context)
    {
        _context = context;
    }

    public List<OrderFullDto> GetOrder()
    {
        var result = (from o in _context.Orders
            join c in _context.Customers on o.CustomerId equals c.Id
            join od in _context.OrderDetails on o.Id equals od.OrderId
            join p in _context.Products on od.ProductId equals p.Id
            select new OrderFullDto()
            {
                Id = o.Id,
                OrderPlaced = o.OrderPlaced,
                OrderFulFilled = o.OrderFulFilled,
                CustomerId = o.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                Phone = c.Phone,
                Email = c.Email,
                ProductId = od.ProductId,
                ProductName = p.Name,
                ProductPrice = p.Price
            }).ToList();
        return result;
    }

    public async Task<GetOrderDto?> GetOrderByDate(DateTime date)
    {
        return await _context.Orders.Select(e => new GetOrderDto()
        {
            Id = e.Id,
            OrderPlaced = e.OrderPlaced,
            OrderFulFilled = e.OrderFulFilled,
            CustomerId = e.CustomerId,
            Customers = e.Customers.FirstName
        }).FirstOrDefaultAsync(p=>p.OrderPlaced==date);
    }
    
    public async Task<GetOrderDto?> GetOrderByDate(int id)
    {
        return await _context.Orders.Select(e => new GetOrderDto()
        {
            Id = e.Id,
            OrderPlaced = e.OrderPlaced,
            OrderFulFilled = e.OrderFulFilled,
            CustomerId = e.CustomerId,
            Customers = e.Customers.FirstName
        }).FirstOrDefaultAsync(p=>p.Id==id);
    }

    public async Task<AddOrderDto> AddOrder(AddOrderDto model)
    {
        var order = new Order(model.OrderPlaced, model.OrderFulFilled, model.CustomerId);
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<AddOrderDto> UpdateOrder(AddOrderDto model)
    {
        var find = await _context.Orders.FindAsync(model.Id);
        find.Id = model.Id;
        find.OrderPlaced = model.OrderPlaced;
        find.OrderFulFilled = model.OrderFulFilled;
        find.CustomerId = model.CustomerId;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var find = await _context.Orders.FindAsync(id);
        _context.Orders.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}