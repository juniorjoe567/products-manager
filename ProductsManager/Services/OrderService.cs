using ProductsManager.Models;
using ProductsManager.Repositories;

namespace ProductsManager.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;

        public OrderService(OrderRepository orderRepository, CustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }


        public void PlaceOrder(Order order, Customer customer)
        {
            _orderRepository.Add(order);
            _customerRepository.Update(customer);
        }
    }
}
