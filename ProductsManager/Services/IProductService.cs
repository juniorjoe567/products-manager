using ProductsManager.Models;

namespace ProductsManager.Services
{
    public interface IProductService
    {
        Task<Product> GetProduct(int  id);
    }
}
