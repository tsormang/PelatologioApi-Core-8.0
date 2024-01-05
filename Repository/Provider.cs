using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PelatologioApi.Data;
using PelatologioApi.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PelatologioApi.Repository
{
    public class Provider : IProvider
    {
        private readonly DataContext _context;

        public Provider(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer> DeleteCustomerData(int id)
        {
            var customerData = await _context.Customers.FindAsync(id);
            if (customerData != null)
            {
                _context.Customers.Remove(customerData);
                await _context.SaveChangesAsync();
                return new Customer { };
            }
            else return new Customer
            {
                Response = "Customer was not found.",
            };
        }

        public async Task<bool> UpdateCustomerData(Customer updatedCustomer)
        {
            try
            {
                var dbCustomer = await _context.Customers.FindAsync(updatedCustomer.Id);
                if (dbCustomer != null)
                {
                    dbCustomer.FirstName = updatedCustomer.FirstName;
                    dbCustomer.LastName = updatedCustomer.LastName;
                    dbCustomer.Address = updatedCustomer.Address;
                    dbCustomer.Email = updatedCustomer.Email;

                    var dbCustomerTel = await _context.Telephone.FindAsync(dbCustomer.TelephoneId);
                    if (dbCustomerTel != null)
                    {
                        dbCustomerTel.House = updatedCustomer.Telephones.House;
                        dbCustomerTel.Mobile = updatedCustomer.Telephones.Mobile;
                        dbCustomerTel.Work = updatedCustomer.Telephones.Work;
                    }
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> AddCustomerData(Customer customer)
        {
            try
            {
                TelephoneDbData newTelephone = new TelephoneDbData()
                {
                    House = customer.Telephones.House,
                    Mobile = customer.Telephones.Mobile,
                    Work = customer.Telephones.Work,
                };

                await _context.Telephone.AddAsync(newTelephone);
                await _context.SaveChangesAsync();
                int newTelephoneId = newTelephone.Id;

                CustomerDbData newCustomer = new CustomerDbData()
                {
                    TelephoneId = newTelephoneId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Email = customer.Email
                };

                await _context.Customers.AddAsync(newCustomer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<Customer> GetCustomerData(int id)
        {
            var customerData = await _context.Customers.FindAsync(id);
            if (customerData != null)
            {
                var telephoneData = _context.Telephone;
                return new Customer
                {
                    Id = customerData.Id,
                    FirstName = customerData.FirstName ?? string.Empty,
                    LastName = customerData.LastName ?? string.Empty,
                    Address = customerData.Address ?? string.Empty,
                    Email = customerData.Email ?? string.Empty,
                    Telephones = telephoneData?.Where(t => t.Id == customerData.TelephoneId).FirstOrDefault()
                };
            }
            else return new Customer
            {
                Response = "Customer was not found.",
            };
        }

        public async Task<IEnumerable<Customer>> GetCustomersData()
        {
            var customersData = await _context.Customers.ToListAsync();
            var telephoneData = await _context.Telephone.ToListAsync();

            if (customersData != null && customersData.Any())
            {
                return customersData.Select(c => new Customer
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    Email = c.Email,
                    Telephones = telephoneData.FirstOrDefault(t => t.Id == c.TelephoneId)
                });
            }
            else return Enumerable.Empty<Customer>();
        }

        
    }
}
