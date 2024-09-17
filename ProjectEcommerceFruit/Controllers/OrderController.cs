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

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetOrdersByUser()
            => Ok(await _orderService.GetOrdersByUserAsync());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersByStore(int storeId)
            => Ok(await _orderService.GetOrdersByStoreAsync(storeId));

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CreateUpdateOrderById([FromForm] OrderRequest request)
            => Ok(await _orderService.CreateUpdateOrderByIdAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> ConfirmOrder([FromForm] int orderId,[FromForm] string trackingId)
            => Ok(await _orderService.ConfirmOrderAsync(orderId, trackingId));

        [HttpPost("[action]")]
        public async Task<IActionResult> CancelOrder([FromForm] int orderId)
            => Ok(await _orderService.CancelOrderAsync(orderId));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderItemByOrderId(int orderId)
    => Ok(await _orderService.GetOrderItemByOrderIdAsync(orderId));
    }
}