using AML.Server.DTOs;
using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IBranchService
    {
        Task<List<Branch>> GetBranches();
        Task<Branch> GetBranch(int branchId);
        Task<Account> UpdateBranch(UpdateBranchRequest request);
    }
}
