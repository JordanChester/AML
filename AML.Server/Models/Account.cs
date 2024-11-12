using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AML.Server.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        private string Email { get; set; }
        [Required]
        private string Password { get; set; }
        [Required]
        private bool Subscribed { get; set; }
        [Required]
        private string Name { get; set; }
        [Required]
        private string Address { get; set; }
        [Required]
        private string PhoneNumber { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
        [ForeignKey(nameof(Branch.BranchId))]
        public int? BranchId { get; set; }
    }
}
