using AML.Server.Data;
using AML.Server.Helpers;
using AML.Server.Interfaces;
using AML.Server.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace AML.Server.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DBContext dbContext;
        private readonly string _pepper;
        private readonly int _iteration = 3;

        public AccountRepository(DBContext dbContext) 
        {
            this.dbContext = dbContext;
            this._pepper = Environment.GetEnvironmentVariable("PasswordHashPepper");
        }

        public async Task<bool> RegisterAccount(Account newAccount, CancellationToken cancellationToken) 
        {
            bool success = false;
            if (newAccount == null)
            {
                return success;
            }

            await dbContext.Accounts.AddAsync(newAccount, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            success = true;

            return success;
        }

        public async Task<Account> VerifyLogin(string email, string password, CancellationToken cancellationToken)
        {
            var account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
            if (account == null)
            {
                throw new Exception("Email or password did not match.");
            }

            var accountHash = PasswordHasher.ComputeHash(password, account.PasswordSalt, _pepper, _iteration);
            if (account.Password != accountHash)
            {
                throw new Exception("Email or password did not match.");
            }

            return account;
        }

        public async Task<Account> UpdateDetails(string email, string updatedAddress, string updatedPhone)
        {
            var account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email);
            if (account != null)
            {
                if (updatedAddress != "")
                {
                    account.Address = updatedAddress;
                }

                if(updatedPhone != "")
                {
                    account.Phone = updatedPhone;
                }

                await dbContext.SaveChangesAsync();
            }

            return account;
        }

        public async Task<Account> ChangePassword(string email, string oldPassword, string newPassword)
        {
            var account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email);
            if (account != null)
            {
                string oldHash = PasswordHasher.ComputeHash(oldPassword, account.PasswordSalt, _pepper, _iteration);
                if (account.Password != oldHash) { throw new Exception("Old password does not match our records."); }

                account.Password = PasswordHasher.ComputeHash(newPassword, account.PasswordSalt, _pepper, _iteration);
                await dbContext.SaveChangesAsync();
            }

            return account;
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
