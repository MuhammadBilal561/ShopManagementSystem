using System;
using System.Collections.Generic;
using ShopManagementSystem.Order;

namespace ShopManagementSystem
{
    internal class OrderService
    {
        private readonly OrderRepository orderRepository;
        public CustomerRepository _customerRepo;
        private readonly OrderRepoDB dbRepo = new OrderRepoDB();

        public OrderService()
        {
            orderRepository = new OrderRepository();
        }

        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = dbRepo.GetAll();
            if (orders.Count == 0)
            {
                return orderRepository.LoadOrders();
            }
            return orders;
        }

        public void CreateNewOrder(OrderModel order)
        {
            bool dbResult = dbRepo.Create(order);
            if (dbResult)
            {
                //file backup
                List<OrderModel> existingOrders = orderRepository.LoadOrders();
                existingOrders.Add(order);
                orderRepository.SaveOrders(existingOrders);
            }
        }
    }
}
