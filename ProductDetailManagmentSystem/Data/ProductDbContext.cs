using Microsoft.EntityFrameworkCore;
using ProductDetailManagmentSystem.Models;

namespace ProductDetailManagmentSystem.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options) 
        {
            
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customer { get; set;}

    }
}
