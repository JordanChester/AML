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
    }
}
