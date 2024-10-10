using Microsoft.EntityFrameworkCore;
using ProductsManager.Data;
using ProductsManager.Models;

namespace ProductsManager.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ProductsManagerContext _context;
        public CustomerRepository(ProductsManagerContext context)
        {
            _context = context;
        }
        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Customers.FirstOrDefault(x => x.Id == id);
            if(entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }
    }
}
