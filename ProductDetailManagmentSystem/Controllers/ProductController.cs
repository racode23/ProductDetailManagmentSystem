using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductDetailManagmentSystem.Interfaces;
using ProductDetailManagmentSystem.Models;
using ProductDetailManagmentSystem.ViewModel;

namespace ProductDetailManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpPost("Add-Product")]
        public async Task<ActionResult> AddProduct(ProductDetailVM product) { 
        
             _productService.AddProduct(product);
             return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> getAllProduct() { 
        
           var result =_productService.getAllProducts();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getProductbyId(int id) { 

        var result = _productService.getProductById(id);
            return Ok(result);
        }
    }
}
