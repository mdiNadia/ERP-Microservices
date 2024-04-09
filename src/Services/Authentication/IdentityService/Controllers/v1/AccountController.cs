using Authentication.Application.Features.IdentityService.Commands;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers.v1
{
    public class AccountController : BaseApiController
    {

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            //Use Of Serilog
            this._logger = logger;
            _logger.LogInformation("AccountController Logs:");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command) => Ok(await Mediator.Send(command));


    }
}
