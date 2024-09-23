using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.OrderS
{
    public interface IOrderService
    {
        Task<List<OrderRespone>> GetOrdersAsync();
        Task<List<TestOrderToReceipt>> GetOrdersWantToReceiptAsync();
        Task<List<OrderRespone>> GetMyOrderToSendAsync(); 
        Task<List<OrderRespone>> GetOrdersByUserAsync();
        Task<List<OrderRespone>> GetOrdersByStoreAsync(int storeId);
        Task<Object> CreateUpdateOrderByIdAsync(OrderRequest request);
        Task<Object> ConfirmOrderAsync(int orderId, string? trackingId, string? shippingType);
        Task<Object> CancelOrderAsync(int orderId);
        Task<Object> ChangeConfirmReceiptOrderAsync(int orderId, int status);
        Task<Object> ChangeConfirmSendOrderAsync(List<int> orderId);

        Task<Object> CreateOrderToReceiptAsync(List<int> orderId);
    }
}
