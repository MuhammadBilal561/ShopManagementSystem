using System;
using System.Collections.Generic;

namespace ShopManagementSystem
{
    internal class OrderService
    {
        private readonly OrderRepository orderRepository;
        public CustomerRepository _customerRepo;

        public OrderService()
        {
            orderRepository = new OrderRepository();
        }

        public List<OrderModel> GetAllOrders()
        {
            return orderRepository.LoadOrders();
        }

        public void CreateNewOrder(OrderModel order)
        {
            List<OrderModel> existingOrders = orderRepository.LoadOrders();

            existingOrders.Add(order);

            orderRepository.SaveOrders(existingOrders);
        }

        // return list of name of all the customers who  got more thean three products and total price is more than 5000;
    }
}
