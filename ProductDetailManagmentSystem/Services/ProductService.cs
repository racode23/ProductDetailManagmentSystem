using Microsoft.EntityFrameworkCore;
using ProductDetailManagmentSystem.Data;
using ProductDetailManagmentSystem.Interfaces;
using ProductDetailManagmentSystem.Models;
using ProductDetailManagmentSystem.ViewModel;
using System.Linq;

namespace ProductDetailManagmentSystem.Services
{
    public class ProductService : IProductService
    {
       
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
           this._dbContext = dbContext;
        }
        public void AddProduct(ProductDetailVM product)
        {  
           //create new product object
           var productObject = new Product();
           
           //Add new view product data to product object
           productObject.Name = product.Name;
           productObject.Description = product.Description;
           productObject.Price = product.Price;
            //Add product
           var result =_dbContext.products.Add(productObject);

            _dbContext.SaveChanges();
           
            
        }

        public void DeleteProduct(int id)
        {
            var result = _dbContext.products.Find(id);
            _dbContext.products.Remove(result);
            _dbContext.SaveChanges();
        }

        public List<Product> getAllProducts()
        {
           var Products= _dbContext.products.ToList();
           return Products;
        }

        public Product getProductById(int id)
        {
             Product product = _dbContext.products.FirstOrDefault(m=>m.Id==id);
             return product;
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
