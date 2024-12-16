using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> VerifyEmail(string email);
        Task<bool> RegisterAccount(Account newAccount, CancellationToken cancellationToken);
        Task<Account> VerifyLogin(string email, string password, CancellationToken cancellationToken);
        Task<Account> UpdateDetails(string email, string address, string phone);
        Task<Account> ChangePassword(string email, string oldPassword, string newPassword);
    }
}
