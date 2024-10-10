using ProductsManager.Models;

namespace ProductsManager.Services
{
    public interface IOrderService
    {
        void PlaceOrder(Order order, Customer customer);

    }
}
