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

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CreateUpdateOrderById(OrderRequest request)
            => Ok(await _orderService.CreateUpdateOrderByIdAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> ConfirmOrder(int orderId)
            => Ok(await _orderService.ConfirmOrderAsync(orderId));

        [HttpPost("[action]")]
        public async Task<IActionResult> CancelOrder(int orderId)
            => Ok(await _orderService.CancelOrderAsync(orderId));
    }
}
