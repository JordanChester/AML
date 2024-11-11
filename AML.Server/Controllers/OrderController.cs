using AML.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AML.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task ReserveMedia(int mediaId, int accountId)
        {
            // add logic
        }

        [HttpPost]
        public async Task BorrowMedia(int mediaId, int accountId, DateTime returnDate)
        {
            // add logic
        }

        [HttpPost]
        public async Task ReturnMedia(int mediaId, int accountId, DateTime dateReturned)
        {
            // add logic
        }
    }
}
