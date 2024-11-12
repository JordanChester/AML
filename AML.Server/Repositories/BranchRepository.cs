using AML.Server.Interfaces;
using AML.Server.Models;

namespace AML.Server.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        // Add a dbcontext here

        public BranchRepository(/*inject dbcontext*/)
        {
            /*Assign injected context to declared above*/
        }

        public async Task CreateBranch(Branch newBranch)
        {
            // add logic
        }

        public async Task<Branch> GetBranch(int branchId)
        {
            // add logic
            return null;
        }

        public async Task<string> GetBranchLocation(int branchId)
        {
            // add logic
            return null;
        }
    }
}
