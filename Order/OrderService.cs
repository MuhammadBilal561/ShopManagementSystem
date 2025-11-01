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

    }
}
