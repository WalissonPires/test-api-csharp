using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Database;
using TestApi.Database.Repositories;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderRepository _orderRepo;

        public OrdersController(OrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepo.Find(new FindOrderSepc());
            return Ok(orders);
        }
    }
}
