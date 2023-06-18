using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("GetCustomet")]
    public async Task<List<CustomerBaseDto>> GetCustomer()
    {
        return await _customerService.GetCustomer();
    }

    [HttpGet("GetByName")]
    public async Task<CustomerBaseDto> GetCustomerByName(string name)
    {
        return await _customerService.GetCustomerByName(name);
    }

    [HttpGet("GetById")]
    public async Task<CustomerBaseDto> GetCustomerById(int id)
    {
        return await _customerService.GetCustomerById(id);
    }

    [HttpPost("AddCustomer")]
    public async Task<CustomerBaseDto> AddCustomer(CustomerBaseDto model)
    {
        return await _customerService.AddCustomer(model);
    }

    [HttpPut("UpdateCustomer")]
    public async Task<CustomerBaseDto> UpdateCustomer(CustomerBaseDto model)
    {
        return await _customerService.UpdateCustomer(model);
    }

    [HttpDelete("DeleteCustomer")]
    public async Task<bool> DeleteCustomer(int id)
    {
        return await _customerService.DeleteCustomer(id);
    }
}