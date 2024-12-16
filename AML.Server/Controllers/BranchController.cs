using AML.Server.DTOs;
using AML.Server.Interfaces;
using AML.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AML.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        [Route("get-branches")]
        public async Task<List<Branch>> GetBranches()
        {
            return await _branchService.GetBranches();
        }

        [HttpGet]
        [Route("get-branch")]
        public async Task<Branch> GetBranch(int branchId)
        {
            return await _branchService.GetBranch(branchId);
        }

        [HttpPost]
        [Route("update-branch")]
        public async Task<Account> UpdateBranch(UpdateBranchRequest request)
        {
            return await _branchService.UpdateBranch(request);
        }
    }
}
