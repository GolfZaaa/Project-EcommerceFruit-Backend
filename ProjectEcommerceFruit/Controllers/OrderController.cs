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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersWantToReceipt() 
            => Ok(await _orderService.GetOrdersWantToReceiptAsync());

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
        public async Task<IActionResult> ChangeConfirmSendOrder([FromForm] List<int> orderId)
            => Ok(await _orderService.ChangeConfirmSendOrderAsync(orderId));

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CreateOrderToReceipt([FromForm] List<int> orderId)
            => Ok(await _orderService.CreateOrderToReceiptAsync(orderId));
    }
}