using AML.Server.DTOs;
using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IAccountService
    {
        Task<bool> VerifyEmail(string email);
        Task<bool> RegisterAccount(RegisterRequest request, CancellationToken cancellationToken);
        Task<LoginResponse> VerifyLogin(LoginRequest request, CancellationToken cancellationToken);
        Task<Account> UpdateDetails(UpdateDetailsRequest request);
        Task<Account> ChangePassword(ChangePasswordRequest request);
    }
}
