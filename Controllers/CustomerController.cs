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
            var customers = _provider.GetCustomerData();
            return Ok(customers);
        }



    }
}
