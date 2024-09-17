using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.OrderS
{
    public interface IOrderService
    {
        Task<List<OrderRespone>> GetOrdersAsync();
        Task<List<OrderRespone>> GetOrdersByUserAsync();
        Task<List<OrderRespone>> GetOrdersByStoreAsync(int storeId);
        Task<Object> CreateUpdateOrderByIdAsync(OrderRequest request);
        Task<Object> ConfirmOrderAsync(int orderId, string trackingId);
        Task<Object> CancelOrderAsync(int orderId);

        Task<dynamic> GetOrderItemByOrderIdAsync(int orderId);

    }
}
