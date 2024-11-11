using AML.Server.Interfaces;
using AML.Server.Models;

namespace AML.Server.Repositories
{
    public class StockRepository : IStockRepository
    {
        // Add a dbcontext here

        public StockRepository(/*inject dbcontext*/)
        {
            /*Assign injected context to declared above*/
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
