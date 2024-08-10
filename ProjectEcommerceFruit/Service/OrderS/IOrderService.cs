﻿using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.OrderS
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync();
        Task<List<OrderRespone>> GetOrdersByUserAsync();
        Task<List<OrderRespone>> GetOrdersByStoreAsync(int storeId);
        Task<Object> CreateUpdateOrderByIdAsync(OrderRequest request);
        Task<Object> ConfirmOrderAsync(int orderId, string trackingId);
        Task<Object> CancelOrderAsync(int orderId);
    }
}
