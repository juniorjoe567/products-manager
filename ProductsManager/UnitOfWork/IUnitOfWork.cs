using ProductsManager.Models;
using ProductsManager.Repositories;

namespace ProductsManager.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> Orders { get; }
        IRepository<Customer> Customers { get; }
        void Complete();
    }
}
