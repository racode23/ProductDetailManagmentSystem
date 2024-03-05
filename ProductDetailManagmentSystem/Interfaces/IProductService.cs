using ProductDetailManagmentSystem.Models;
using ProductDetailManagmentSystem.ViewModel;

namespace ProductDetailManagmentSystem.Interfaces
{
    public interface IProductService
    {
        public List<Product> getAllProducts();
        public Product getProductById(int id);

        public void AddProduct(ProductDetailVM product);

        public Product UpdateProduct(Product product);

        public void DeleteProduct(int id);


    }
}
