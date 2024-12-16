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
    }
}
