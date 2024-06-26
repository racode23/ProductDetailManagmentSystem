﻿using Microsoft.EntityFrameworkCore;
using ProductDetailManagmentSystem.Data;
using ProductDetailManagmentSystem.Interfaces;
using ProductDetailManagmentSystem.Models;
using ProductDetailManagmentSystem.ViewModel;

namespace ProductDetailManagmentSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ProductDbContext DbContext;
        public CustomerService(ProductDbContext productDb )
        {
            DbContext = productDb;
        }
        public void CreateCustomer(CustomerVm customer)
        {
            Customer customer1 = new Customer();
            customer1.Name = customer.Name;
            customer1.Email = customer.Email;

             DbContext.customer.Add( customer1 );
             DbContext.SaveChanges();

            
        }

        public void DeleteCustomer(int id)
        {
            var customer=DbContext.customer.Find(id);
            DbContext.customer.Remove(customer);
            DbContext.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            var Customers=DbContext.customer.ToList();
            return Customers;
        }

        public Customer GetCustomerById(int id)
        {
            var customer =DbContext.customer.FirstOrDefault<Customer>(x=>x.Id==id);
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
