using AML.Server.Data;
using AML.Server.DTOs;
using AML.Server.Helpers;
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
        private readonly string _pepper;
        private readonly int _iteration = 3;

        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
            this._pepper = Environment.GetEnvironmentVariable("PasswordHashPepper");
        }

        [HttpPost]
        [Route("register-account")]
        public async Task<bool> RegisterAccount(RegisterRequest request, CancellationToken cancellationToken)
        {
            bool success = false;
            string salt = PasswordHasher.GenerateSalt();

            Account newAccount = new Account(){
                Email = request.Email,
                PasswordSalt = salt,
                Password = PasswordHasher.ComputeHash(request.Password, salt, _pepper, _iteration),
                Subscribed = true,
                Name = request.Name,
                Address = request.Address,
                PhoneNumber = request.Phone,
                AccountType = request.AccountType
            };

            success = await _accountRepository.RegisterAccount(newAccount, cancellationToken);

            return success;
        }

        [HttpPost]
        [Route("verify-login")]
        public async Task<LoginResponse> VerifyLogin(LoginRequest request, CancellationToken cancellationToken)
        {
            Account account = await _accountRepository.VerifyLogin(request.Email, request.Password, cancellationToken);
            LoginResponse response = new LoginResponse();
            response.Email = account.Email;
            response.Name = account.Name;
            response.Address = account.Address;
            response.Phone = account.PhoneNumber;

            return response;
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
