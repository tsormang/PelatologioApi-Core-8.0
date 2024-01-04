using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PelatologioApi.Data;
using PelatologioApi.Entities;
using System.Collections;
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

        public Customer DeleteCustomerData(int id)
        {
            var customerData = _context.Customers.Find(id);
            if (customerData != null)
            {
                _context.Customers.Remove(customerData);
                _context.SaveChanges();
                return new Customer { };
            }
            else return new Customer
            {
                Response = "Customer was not found.",
            };
        }

        public void UpdateCustomerData(Customer updatedCustomer)
        {
            var dbCustomer = _context.Customers.Find(updatedCustomer.Id);
            if (dbCustomer != null)
            {
                dbCustomer.FirstName = updatedCustomer.FirstName;
                dbCustomer.LastName = updatedCustomer.LastName;
                dbCustomer.Address = updatedCustomer.Address;
                dbCustomer.Email = updatedCustomer.Email;
            }
            var dbCustomerTel = _context.Telephone.Find(dbCustomer.TelephoneId);
            if (dbCustomerTel != null)
            {
                dbCustomerTel.House = updatedCustomer.Telephones.House;
                dbCustomerTel.Mobile = updatedCustomer.Telephones.Mobile;
                dbCustomerTel.Work = updatedCustomer.Telephones.Work;
            }
            _context.SaveChanges();
        }

        public void AddCustomerData(Customer customer)
        {
            TelephoneDbData newTelephone = new TelephoneDbData()
            {
                House = customer.Telephones.House,
                Mobile = customer.Telephones.Mobile,
                Work = customer.Telephones.Work,
            };

            _context.Telephone.Add(newTelephone);
            _context.SaveChanges();
            int newTelephoneId = newTelephone.Id;

            CustomerDbData newCustomer = new CustomerDbData()
            {
                TelephoneId = newTelephoneId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Email = customer.Email
            };
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
        }

        public Customer GetCustomerData(int id)
        {
            var customerData = _context.Customers.Find(id);
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

        public IEnumerable<Customer> GetCustomersData()
        {
            var customersData = _context.Customers;
            var telephoneData = _context.Telephone;
            if (customersData != null && customersData.Any())
            {
                return customersData.Select(c => new Customer
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    Email = c.Email,
                    Telephones = telephoneData.Where(t => t.Id == c.TelephoneId).FirstOrDefault()
                });
            }
            else return Enumerable.Empty<Customer>();
        }

        
    }
}
