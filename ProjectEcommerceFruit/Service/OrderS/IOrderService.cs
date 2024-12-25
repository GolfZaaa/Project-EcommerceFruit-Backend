using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.OrderS
{
    public interface IOrderService
    {
        Task<List<OrderRespone>> GetOrdersAsync();
        Task<Object> CancelOrderMyReceiptAsync(int driverHisId);
        Task<List<TestOrderToReceipt>> GetOrdersWantToReceiptAsync();
        Task<Object> IWantToTakeOrdertoSendAsync(List<int> orderId);
        Task<List<OrderRespone>> GetMyOrderUserWantToTaketoSendAsync();
        Task<Object> ConfirmOrderToForwardAsync(int driverId, int shippingId, int shippingFee);
        Task<List<TestOrderToReceipt>> SearchOrdersWantToReceiptAsync(string? district, string? subDistrict);
        Task<List<OrderRespone>> SearchOrderToSendByOrderIdAsync(string? orderId);
        Task<List<OrderRespone>> GetMyOrderToSendAsync(); 
        Task<List<OrderRespone>> GetOrdersByUserAsync();
        Task<List<OrderRespone>> GetOrdersByStoreAsync(int storeId);
        Task<Object> CreateUpdateOrderByIdAsync(OrderRequest request);
        Task<Object> ConfirmOrderAsync(int orderId, string? trackingId, string? shippingType);
        Task<Object> CancelOrderAsync(int orderId);
        Task<Object> ChangeConfirmReceiptOrderAsync(int orderId, int status);
        Task<Object> ChangeConfirmSendOrderAsync(ConfirmSendOrder request);

        Task<Object> CreateOrderToReceiptAsync(List<int> orderId);

        Task<dynamic> GetOrderItemByOrderIdAsync(int orderId);

        Task<dynamic> RefundOrderAsync(int orderId);

    }
}
