using ProductDetailManagmentSystem.Models;

namespace ProductDetailManagmentSystem.Interfaces
{
    public interface ICustomerService
    {
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public void  UpdateCustomer(Customer customer);

        public void DeleteCustomer(int id);


    }
}
