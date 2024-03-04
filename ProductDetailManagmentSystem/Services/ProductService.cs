using ProductDetailManagmentSystem.Interfaces;
using ProductDetailManagmentSystem.Models;

namespace ProductDetailManagmentSystem.Services
{
    public class ProductService : IProductService
    {
        public ProductService _productService;

        public ProductService(ProductService productService)
        {
           this._productService = productService;
        }
        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product getProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
