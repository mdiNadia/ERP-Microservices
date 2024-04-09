using CRM.Aggregator.Extensions;
using CRM.Aggregator.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;
        public AccountService(HttpClient client)
        {
            _client = client;
        }
        public async Task<LoginResult> Login(LoginModel command)
        {
            var response = await _client.PostAsJsonAsync("/api/v1/Account/Login", command);
            return await response.ReadContentAs<LoginResult>();
        }
    }
}
