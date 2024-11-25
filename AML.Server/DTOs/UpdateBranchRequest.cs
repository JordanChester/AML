using AML.Server.Models;

namespace AML.Server.DTOs
{
    public class UpdateBranchRequest
    {
        public string Email { get; set; }
        public Branch Branch { get; set; }
    }
}
