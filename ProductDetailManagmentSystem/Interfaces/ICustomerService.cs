using ProductDetailManagmentSystem.Models;
using ProductDetailManagmentSystem.ViewModel;

namespace ProductDetailManagmentSystem.Interfaces
{
    public interface ICustomerService
    {
        public void CreateCustomer(CustomerVm customer);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public void  UpdateCustomer(Customer customer);
        public void DeleteCustomer(int id);



    }
}
