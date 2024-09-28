using Microsoft.EntityFrameworkCore;
using ProductsManager.Data;
using ProductsManager.Models;

namespace ProductsManager.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ProductsManagerContext _context;
        public ProductRepository(ProductsManagerContext context)
        {
            _context = context;
        }
        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Products.FirstOrDefault(x => x.Id == id);
            if(entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
