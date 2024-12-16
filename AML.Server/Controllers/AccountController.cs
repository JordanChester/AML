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
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpGet]
        [Route("verify-email")]
        public async Task<bool> VerifyEmail(string email)
        {
            bool success = false;
            success = await _accountService.VerifyEmail(email);
            return success;
        }

        [HttpPost]
        [Route("register-account")]
        public async Task<bool> RegisterAccount(RegisterRequest request, CancellationToken cancellationToken)
        {
            bool success = false;
            success = await _accountService.RegisterAccount(request, cancellationToken);
            return success;
        }

        [HttpPost]
        [Route("verify-login")]
        public async Task<LoginResponse> VerifyLogin(LoginRequest request, CancellationToken cancellationToken)
        {
            LoginResponse response = await _accountService.VerifyLogin(request, cancellationToken);
            return response;
        }

        [HttpPost]
        [Route("update-details")]
        public async Task<Account> UpdateDetails(UpdateDetailsRequest request)
        {
            return await _accountService.UpdateDetails(request);
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<Account> ChangePassword(ChangePasswordRequest request)
        {
            return await _accountService.ChangePassword(request);
        }
    }
}
