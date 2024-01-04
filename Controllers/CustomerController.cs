using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PelatologioApi.Data;
using PelatologioApi.Entities;
using PelatologioApi.Repository;

namespace PelatologioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IProvider _provider;

        public CustomerController(IProvider provider)
        {
            _provider = provider;
        }


        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = _provider.GetCustomersData();
            if (!customers.Any())
                return NotFound("No Customers found.");
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = _provider.GetCustomerData(id);

            if (!string.IsNullOrEmpty(customer.Response))
                return NotFound(customer.Response);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            _provider.AddCustomerData(customer);
            return Ok(_provider.GetCustomersData());
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer updatedCustomer)
        {
            _provider.UpdateCustomerData(updatedCustomer);
            return Ok(_provider.GetCustomersData());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var customer = _provider.DeleteCustomerData(id);

            if (!string.IsNullOrEmpty(customer.Response))
                return NotFound(customer.Response);

            return Ok(_provider.GetCustomersData());
        }

    }
}
