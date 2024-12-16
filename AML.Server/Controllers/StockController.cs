using AML.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AML.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
    }
}
