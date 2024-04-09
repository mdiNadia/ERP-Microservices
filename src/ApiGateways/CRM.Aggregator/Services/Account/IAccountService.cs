using CRM.Aggregator.Models.Account;

namespace CRM.Aggregator.Services.Account
{
    public interface IAccountService
    {
        Task<LoginResult> Login(LoginModel command);

    }
}
