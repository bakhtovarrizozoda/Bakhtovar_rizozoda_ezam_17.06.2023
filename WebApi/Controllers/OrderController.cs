using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetOrder")]
    public List<OrderFullDto> GerOrder()
    {
        return  _orderService.GetOrder();
    }

    [HttpGet("GetByDate")]
    public async Task<GetOrderDto> GetorderByDate(DateTime date)
    {
        return await _orderService.GetOrderByDate(date);
    }
    
    [HttpGet("GetById")]
    public async Task<GetOrderDto> GetorderById(int id)
    {
        return await _orderService.GetOrderByDate(id);
    }

    [HttpPost("AddOrder")]
    public async Task<AddOrderDto> AddOrder(AddOrderDto model)
    {
        return await _orderService.AddOrder(model);
    }

    [HttpPut("UpdateOrder")]
    public async Task<AddOrderDto> UpdateOrder(AddOrderDto model)
    {
        return await _orderService.UpdateOrder(model);
    }

    [HttpDelete("DeleteOrder")]
    public async Task<bool> DeleteOrder(int id)
    {
        return await _orderService.DeleteOrder(id);
    }
}