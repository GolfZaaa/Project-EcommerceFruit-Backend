using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Dtos.Cart;
using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Service.OrderS;

namespace ProjectEcommerceFruit.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrders()
            => Ok(await _orderService.GetOrdersAsync());

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CancelOrderMyReceipt(int driverHisId)
           => Ok(await _orderService.CancelOrderMyReceiptAsync(driverHisId));
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersWantToReceipt() 
            => Ok(await _orderService.GetOrdersWantToReceiptAsync());

        [HttpPost("[action]")]
        public async Task<IActionResult> IWantToTakeOrdertoSend([FromForm] List<int> orderId)
            => Ok(await _orderService.IWantToTakeOrdertoSendAsync(orderId));

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetMyOrderUserWantToTaketoSend()
            => Ok(await _orderService.GetMyOrderUserWantToTaketoSendAsync());

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> ConfirmOrderToForward([FromForm] int driverId, [FromForm] int shippingId, [FromForm] int shippingFee)
            => Ok(await _orderService.ConfirmOrderToForwardAsync(driverId, shippingId, shippingFee));

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchOrdersWantToReceipt([FromQuery] string? district, [FromQuery] string? subDistrict)
            => Ok(await _orderService.SearchOrdersWantToReceiptAsync(district, subDistrict));

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> SearchOrderToSendByOrderId(string? orderId)
            => Ok(await _orderService.SearchOrderToSendByOrderIdAsync(orderId));
        
        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetOrdersByUser()
            => Ok(await _orderService.GetOrdersByUserAsync());

        [HttpGet("[action]"), Authorize] 
        public async Task<IActionResult> GetMyOrderToSend()
            => Ok(await _orderService.GetMyOrderToSendAsync());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersByStore(int storeId)
            => Ok(await _orderService.GetOrdersByStoreAsync(storeId));

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CreateUpdateOrderById([FromForm] OrderRequest request)
            => Ok(await _orderService.CreateUpdateOrderByIdAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> ConfirmOrder([FromForm] int orderId,[FromForm] string? trackingId, [FromForm] string? shippingType)
            => Ok(await _orderService.ConfirmOrderAsync(orderId, trackingId, shippingType));

        [HttpPost("[action]")]
        public async Task<IActionResult> CancelOrder([FromForm] int orderId)
            => Ok(await _orderService.CancelOrderAsync(orderId));

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeConfirmReceiptOrder([FromForm] int orderId, [FromForm] int status)
            => Ok(await _orderService.ChangeConfirmReceiptOrderAsync(orderId, status));

        [HttpPost("[action]")] 
        public async Task<IActionResult> ChangeConfirmSendOrder([FromForm] ConfirmSendOrder request)
            => Ok(await _orderService.ChangeConfirmSendOrderAsync(request));

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CreateOrderToReceipt([FromForm] List<int> orderId)
            => Ok(await _orderService.CreateOrderToReceiptAsync(orderId));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderItemByOrderId(int orderId)
        => Ok(await _orderService.GetOrderItemByOrderIdAsync(orderId));

        [HttpPost("[action]")]
        public async Task<IActionResult> RefundOrder(int orderId)
        => Ok(await _orderService.RefundOrderAsync(orderId));
    }
}