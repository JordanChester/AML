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

        public async Task<Branch> GetBranch(int branchId)
        {
            var branch = await dbContext.Branches.FirstOrDefaultAsync(x => x.Id == branchId);

            if (branch == null)
            {
                throw new Exception("Branch not found.");
            }

            return branch;
        }

        public async Task<Account> UpdateBranch(string email, Branch updatedBranch)
        {
            var account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email);

            if (account == null)
            {
                throw new Exception("Error finding user with email address provided.");
            }

            account.BranchId = updatedBranch.Id;
            await dbContext.SaveChangesAsync();

            return account;
        }
    }
}
