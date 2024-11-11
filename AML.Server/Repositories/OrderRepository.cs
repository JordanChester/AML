using AML.Server.Interfaces;

namespace AML.Server.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // Add a dbcontext here

        public OrderRepository(/*inject dbcontext*/)
        {
            /*Assign injected context to declared above*/
        }

        public async Task ReserveMedia(int mediaId, int accountId)
        {
            // add logic
            return null;
        }

        public async Task BorrowMedia(int mediaId, int accountId, DateTime returnDate)
        {
            // add logic
            return null;
        }

        public async Task ReturnMedia(int mediaId, int accountId, DateTime dateReturned)
        {
            // add logic
            return null;
        }
    }
}
