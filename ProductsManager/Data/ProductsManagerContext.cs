using Microsoft.EntityFrameworkCore;
using ProductsManager.Models;

namespace ProductsManager.Data
{
    public class ProductsManagerContext : DbContext
    {
        public ProductsManagerContext(DbContextOptions<ProductsManagerContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

    }
}
