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

        [HttpGet]
        [Route("verify-email")]
        public async Task<bool> VerifyEmail(string email)
        {
            bool success = false;
            success = await _accountRepository.VerifyEmail(email);
            return success;
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
                Phone = request.Phone,
                AccountType = request.AccountType,
                BranchId = request.Branch.Id
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
            response.Phone = account.Phone;
            response.BranchId = account.BranchId;

            return response;
        }

        [HttpPost]
        [Route("update-details")]
        public async Task<Account> UpdateDetails(UpdateDetailsRequest request)
        {
            string updatedAddress = request.Address == null ? "" : request.Address;
            string updatedPhone = request.Phone == null ? "" : request.Phone;

            if (updatedAddress == "" && updatedPhone == "") throw new Exception("No valid data provided.");

            return await _accountRepository.UpdateDetails(request.Email, updatedAddress, updatedPhone);
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<Account> ChangePassword(ChangePasswordRequest request)
        {
            return await _accountRepository.ChangePassword(request.Email, request.OldPassword, request.NewPassword);
        }
    }
}
