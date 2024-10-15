using Microsoft.EntityFrameworkCore;
using ProductsManager.Data;
using ProductsManager.Models;

namespace ProductsManager.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ProductsManagerContext _context;
        public OrderRepository(ProductsManagerContext context)
        {
            _context = context;
        }
        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Orders.FirstOrDefault(x => x.Id == id);
            if(entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public Order GetById(int id)
        {
            return _context.Orders.Find(id);
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
