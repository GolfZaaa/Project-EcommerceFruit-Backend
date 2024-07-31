using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.OrderS
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync();
        Task<List<OrderRespone>> GetOrdersByUserAsync();
        Task<Object> CreateUpdateOrderByIdAsync(OrderRequest request);
        Task<Object> ConfirmOrderAsync(int orderId);
        Task<Object> CancelOrderAsync(int orderId);
    }
}
