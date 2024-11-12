using AML.Server.Interfaces;
using AML.Server.Models;

namespace AML.Server.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        // Add a dbcontext here

        public AccountRepository(/*inject dbcontext*/) 
        {
            /*Assign injected context to declared above*/
        }

        public Task RegisterAccount(Account newAccount) 
        {
            // add logic
            return null;
        }

        public Task<bool> VerifyLogin(string email, string password)
        {
            // add logic
            return null;
        }

        public Task<Account> GetAccount(string email, string password)
        {
            // add logic
            return null;
        }

        public Task UpdatePhoneNumber(string newPhoneNumber)
        {
            // add logic
            return null;
        }

        public Task UpdateAddress(string newAddress)
        {
            // add logic
            return null;
        }

        public Task ChangePassword(string newPassword)
        {
            // add logic
            return null;
        }

        public Task Subscribe(int accountId)
        {
            // add logic
            return null;
        }

        public Task Unsubscribe(int accountId)
        {
            // add logic
            return null;
        }
    }
}
