﻿using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IAccountRepository
    {
        Task RegisterAccount(AccountModel newAccount);
        Task<bool> VerifyLogin(string email, string password);
        Task<AccountModel> GetAccount(string email, string password);
        Task UpdatePhoneNumber(string newPhoneNumber);
        Task UpdateAddress(string newAddress);
        Task ChangePassword(string newPassword);
        Task Subscribe(int accountId);
        Task Unsubscribe(int accountId);
    }
}