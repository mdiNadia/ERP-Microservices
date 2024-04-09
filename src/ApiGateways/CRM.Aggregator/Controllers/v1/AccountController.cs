using CRM.Aggregator.Models.Account;
using CRM.Aggregator.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Controllers.v1
{

    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Login")]
        public async Task<LoginResult> Login(LoginModel command)
        {
            var response = await _accountService.Login(command);
            return response;
        }
    }
}
