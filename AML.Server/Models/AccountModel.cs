namespace AML.Server.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        private bool Subscribed { get; set; }
        private string Name { get; set; }
        private string Address { get; set; }
        private string PhoneNumber { get; set; }
        public AccountType AccountType { get; set; }
        public int? BranchId { get; set; }

        public AccountModel(int accountId, string email, string password, bool subscribed, string name, string address, string phoneNumber, AccountType accountType, int? branchId)
        {
            AccountId = accountId;
            Email = email;
            Password = password;
            Subscribed = subscribed;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            AccountType = accountType;
            BranchId = branchId;
        }
    }
}
