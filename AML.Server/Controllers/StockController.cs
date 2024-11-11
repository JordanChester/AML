using AML.Server.Interfaces;

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

        public async Task GetStockForBranch(int branchId, int mediaId, int amount)
        {
            // add logic
            return null;
        }

        public async Task RemoveMedia(int branchId, int mediaId)
        {
            // add logic
            return null;
        }
    }
}
