using AML.Server.Data;
using AML.Server.Helpers;
using AML.Server.Interfaces;
using AML.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

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
