using AML.Server.Interfaces;
using AML.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AML.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController
    {
        private readonly IBranchRepository _branchRepository;

        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
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
