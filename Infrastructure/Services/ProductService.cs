using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<ProductBaseDto>> GetProduct()
    {
        return await _context.Products.Select(e=>new ProductBaseDto()
        {
            Id = e.Id,
            Name = e.Name,
            Price = e.Price
        }).ToListAsync();
    }

    public async Task<ProductBaseDto?> GetProductByName(string name)
    {
        return await _context.Products.Select(e => new ProductBaseDto()
        {
            Id = e.Id,
            Name = e.Name,
            Price = e.Price
        }).FirstOrDefaultAsync(p => p.Name == name);
    }
    
    public async Task<ProductBaseDto?> GetProductById(int id)
    {
        return await _context.Products.Select(e => new ProductBaseDto()
        {
            Id = e.Id,
            Name = e.Name,
            Price = e.Price
        }).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<ProductBaseDto> AddProduct(ProductBaseDto model)
    {
        var product = new Product(model.Name, model.Price);
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        model.Id = product.Id;
        return model;
    }

    public async Task<ProductBaseDto> UpdateProduct(ProductBaseDto model)
    {
        var find = await _context.Products.FindAsync(model.Id);
        find.Id = model.Id;
        find.Name = model.Name;
        find.Price = model.Price;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var find = await _context.Products.FindAsync(id);
        _context.Products.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
}