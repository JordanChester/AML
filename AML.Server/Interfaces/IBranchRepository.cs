using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IBranchRepository
    {
        Task CreateBranch(Branch newBranch);
        Task<Branch> GetBranch(int branchId);
        Task<string> GetBranchLocation(int branchId);
    }
}
