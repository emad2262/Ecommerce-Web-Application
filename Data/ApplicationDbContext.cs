using Microsoft.EntityFrameworkCore;
using Ecommerce_Web_Application.Models;

namespace Ecommerce_Web_Application.Data
{
    
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> brands { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EcommerceWeb;Integrated Security=True;Connect Timeout=30;Encrypt=True;" 
                +"Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");


        }
    }
}
