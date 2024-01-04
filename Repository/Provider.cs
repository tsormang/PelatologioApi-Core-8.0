using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PelatologioApi.Data;
using PelatologioApi.Entities;
using System.Collections.Generic;

namespace PelatologioApi.Repository
{
    public class Provider : IProvider
    {
        private readonly DataContext _context;

        public Provider(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomerData()
        {
            var customersData = _context.Customers;
            var telephoneData = _context.Telephone;

            return customersData.Select(c => new Customer
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                Email = c.Email,
                Telephones = telephoneData.Where(t => t.Id == c.TelephoneId).FirstOrDefault()
            });
        }
    }
}
