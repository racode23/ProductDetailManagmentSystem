using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductDetailManagmentSystem.Models;

namespace ProductDetailManagmentSystem.Data
{
    public class ProductDbContext:IdentityDbContext<IdentityUser>
    {
        public ProductDbContext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customer { get; set;}

    }
}
