using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductsManager.Models;

namespace ProductsManager.Data
{
    public class ProductsManagerContext : IdentityDbContext<ApplicationUser>
    {
        public ProductsManagerContext(DbContextOptions<ProductsManagerContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

    }
}
