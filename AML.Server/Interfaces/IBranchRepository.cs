using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IBranchRepository
    {
        Task CreateBranch(BranchModel newBranch);
        Task<BranchModel> GetBranch(int branchId);
        Task<string> GetBranchLocation(int branchId);
    }
}
