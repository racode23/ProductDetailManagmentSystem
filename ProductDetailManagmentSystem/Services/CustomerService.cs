using Microsoft.EntityFrameworkCore;
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
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            var Customers=DbContext.customer.ToList();
            return Customers;
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
