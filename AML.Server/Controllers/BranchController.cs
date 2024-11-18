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

        [HttpPost]
        [Route("create-branch")]
        public async Task CreateBranch(Branch newBranch)
        {
            // add logic
        }

        [HttpGet]
        [Route("get-branch")]
        public async Task<Branch> GetBranch(int branchId)
        {
            // add logic
            return null;
        }

        [HttpGet]
        [Route("get-location")]
        public async Task<string> GetBranchLocation(int branchId)
        {
            // add logic
            return null;
        }
    }
}
