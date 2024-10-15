using ProductsManager.Models;
using ProductsManager.Repositories;
using ProductsManager.UnitOfWork;

namespace ProductsManager.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void PlaceOrder(Order order, Customer customer)
        {
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Complete();
        }
    }
}
