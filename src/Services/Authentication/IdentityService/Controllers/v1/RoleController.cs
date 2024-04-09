using Authentication.Application.Features.IdentityService.Commands;
using Authentication.Application.Features.User.Queries;
using IdentityService.Filter;
using IdentityService.Helpers;
using IdentityService.Services;
using IdentityService.Wrappers;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace IdentityService.Controllers.v1
{
    public class RoleController : BaseApiController
    {
        private readonly ILogger<RoleController> _logger;

        private readonly IUriService _uriService;

        public RoleController(ILogger<RoleController> logger, IUriService uriService)
        {
            this._uriService = uriService;
            //Use Of Serilog
            this._logger = logger;
            _logger.LogInformation("UserController Logs:");
        }



    }
}
