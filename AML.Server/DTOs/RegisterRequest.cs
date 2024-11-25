using AML.Server.Models;

namespace AML.Server.DTOs
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Branch Branch { get; set; }
    }
}
