using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetBranches();
    }
}
