using ProductDetailManagmentSystem.Models;

namespace ProductDetailManagmentSystem.Interfaces
{
    public interface IProductService
    {
        public List<Product> getAllProducts();
        public Product getProductById(int id);

        public Product AddProduct(Product product);

        public Product UpdateProduct(Product product);

        public void DeleteProduct(int id);


    }
}
