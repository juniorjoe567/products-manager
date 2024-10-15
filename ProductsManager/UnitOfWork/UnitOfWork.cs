using ProductsManager.Data;
using ProductsManager.Models;
using ProductsManager.Repositories;

namespace ProductsManager.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Order> Orders { get; private set; }
        public IRepository<Customer> Customers { get; private set; }
        private readonly ProductsManagerContext _context;

        public UnitOfWork(ProductsManagerContext context)
        {
            _context = context;
            Orders = new OrderRepository(_context);
            Customers = new CustomerRepository(_context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
