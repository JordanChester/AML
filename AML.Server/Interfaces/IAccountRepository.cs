using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> RegisterAccount(Account newAccount, CancellationToken cancellationToken);
        Task<Account> VerifyLogin(string email, string password, CancellationToken cancellationToken);
        Task<Account> GetAccount(string email, string password);
        Task UpdatePhoneNumber(string newPhoneNumber);
        Task UpdateAddress(string newAddress);
        Task ChangePassword(string newPassword);
        Task Subscribe(int accountId);
        Task Unsubscribe(int accountId);
    }
}
