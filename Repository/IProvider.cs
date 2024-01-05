using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PelatologioApi.Data;
using PelatologioApi.Entities;
using System.Collections.Generic;

namespace PelatologioApi.Repository
{
    public interface IProvider
    {
        Task<IEnumerable<Customer>> GetCustomersData();
        Task<Customer> GetCustomerData(int id);

        Task<bool> AddCustomerData(Customer customer);
        Task<bool> UpdateCustomerData(Customer customer);

        Task<Customer> DeleteCustomerData(int id);
    }

}
