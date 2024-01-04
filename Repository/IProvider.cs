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
        IEnumerable<Customer> GetCustomersData();
        Customer GetCustomerData(int id);
        void AddCustomerData(Customer customer);
        void UpdateCustomerData(Customer customer);
        Customer DeleteCustomerData(int id);
    }

}
