using AML.Server.DTOs;
using AML.Server.Interfaces;
using AML.Server.Models;

namespace AML.Server.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<List<Branch>> GetBranches()
        {
            return await _branchRepository.GetBranches();
        }

        public async Task<Branch> GetBranch(int branchId)
        {
            return await _branchRepository.GetBranch(branchId);
        }

        public async Task<Account> UpdateBranch(UpdateBranchRequest request)
        {
            return await _branchRepository.UpdateBranch(request.Email, request.Branch);
        }
    }
}
