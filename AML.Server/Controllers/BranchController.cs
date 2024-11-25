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

        [HttpGet]
        [Route("get-branches")]
        public async Task<List<Branch>> GetBranches()
        {
            return await _branchRepository.GetBranches();
        }
    }
}
