using AML.Server.Data;
using AML.Server.Interfaces;
using AML.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AML.Server.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DBContext dbContext;

        public BranchRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Branch>> GetBranches()
        {
            List<Branch> branches = new List<Branch>();

            branches = await dbContext.Branches.ToListAsync();

            return branches;
        }
    }
}
