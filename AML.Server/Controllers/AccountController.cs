using AML.Server.DTOs;
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

        [HttpPost]
        [Route("register-account")]
        public async Task<bool> RegisterAccount(RegisterRequest request)
        {
            bool success = false;

            if (request.Email == "abc@hotmail.com")
            {
                success = true;
            }

            // Logic going to repo & return success response
            return success;
        }

        [HttpGet]
        [Route("verify-login")]
        public async Task<bool> VerifyLogin(string email, string password)
        {
            // Logic going to repo & return bool response
            bool verified = true;
            return verified;
        }

        [HttpGet]
        [Route("get-account")]
        public async Task<Account> GetAccount(string email, string password)
        {
            // Logic going to repo & return Account
            return null;
        }

        [HttpPost]
        [Route("update-phone")]
        public async Task<bool> UpdatePhoneNumber(string newPhoneNumber)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpPost]
        [Route("update-address")]
        public async Task<bool> UpdateAddress(string newAddress)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<bool> ChangePassword(string newPassword)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpPost]
        [Route("subscribe")]
        public async Task<bool> Subscribe(int accountId)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }

        [HttpPost]
        [Route("unsubscribe")]
        public async Task<bool> Unsubscribe(int accountId)
        {
            // Logic going to repo & return success response
            bool success = true;
            return success;
        }
    }
}
