using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetProduct")]
    public async Task<List<ProductBaseDto>> GetProduct()
    {
        return await _productService.GetProduct();
    }

    [HttpGet("GetByName")]
    public async Task<ProductBaseDto> GetProductByName(string name)
    {
        return await _productService.GetProductByName(name);
    }
    
    [HttpGet("GetById")]
    public async Task<ProductBaseDto> GetProductById(int id)
    {
        return await _productService.GetProductById(id);
    }

    [HttpPost("AddProduct")]
    public async Task<ProductBaseDto> AddProduct(ProductBaseDto model)
    {
        return await _productService.AddProduct(model);
    }

    [HttpPut("UpdateProduct")]
    public async Task<ProductBaseDto> UpdateProduct(ProductBaseDto model)
    {
        return await _productService.UpdateProduct(model);
    }

    [HttpDelete("DeleteProduct")]
    public async Task<bool> DeleteProduct(int id)
    {
        return await _productService.DeleteProduct(id);
    }
}