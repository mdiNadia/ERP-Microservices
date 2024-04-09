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
    public class UserRoleController : BaseApiController
    {
        private readonly ILogger<UserRoleController> _logger;

        private readonly IUriService _uriService;

        public UserRoleController(ILogger<UserRoleController> logger, IUriService uriService)
        {
            this._uriService = uriService;
            //Use Of Serilog
            this._logger = logger;
            _logger.LogInformation("UserRoleController Logs:");
        }

        /// <summary>
        /// Gets all Users with paging filter.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetAll(DataSourceLoadOptions loadOptions)
        {
            var result = await Mediator.Send(new GetAllUsers());
            return DataSourceLoader.Load(result, loadOptions);
        }

        /// <summary>
        /// Gets User Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var AdCategory = await Mediator.Send(new GetUserById { Id = id });
            return Ok(new Response<GetUserDto>(AdCategory));
        }

    }
}
