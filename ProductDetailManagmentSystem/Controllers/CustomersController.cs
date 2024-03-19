using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductDetailManagmentSystem.Interfaces;
using ProductDetailManagmentSystem.ViewModel;

namespace ProductDetailManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public readonly ICustomerService customerService;
        public CustomersController(ICustomerService _customerService)
        {
            this.customerService = _customerService;

        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerVm customer)
        {

            customerService.CreateCustomer(customer);
            return Ok();

        }


        [HttpGet]
        public async Task<ActionResult> getAllCustomers() {

            var customers =customerService.GetAllCustomers();
            return Ok(customers);

        }
    }
}
