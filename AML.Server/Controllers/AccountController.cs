using AML.Server.Interfaces;
using AML.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AML.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<bool> RegisterAccount(/*Request Object*/)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpGet]
        public async Task<bool> VerifyLogin(string email, string password)
        {
            // Logic going to repo & return bool response
            bool verified = true;
            return verified;
        }

        [HttpGet]
        public async Task<Account> GetAccount(string email, string password)
        {
            // Logic going to repo & return Account
            return null;
        }

        [HttpPost]
        public async Task<bool> UpdatePhoneNumber(string newPhoneNumber)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpPost]
        public async Task<bool> UpdateAddress(string newAddress)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpPost]
        public async Task<bool> ChangePassword(string newPassword)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpPost]
        public async Task<bool> Subscribe(int accountId)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpPost]
        public async Task<bool> Unsubscribe(int accountId)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }
    }
}
