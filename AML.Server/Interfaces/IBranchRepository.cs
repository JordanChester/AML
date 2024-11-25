using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetBranches();
        Task<Branch> GetBranch(int branchId);
        Task<Account> UpdateBranch(string email, Branch updatedBranch);
    }
}
