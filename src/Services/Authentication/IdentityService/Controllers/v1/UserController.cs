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
    public class UserController : BaseApiController
    {
        private readonly IUriService _uriService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUriService uriService)
        {
            this._uriService = uriService;
            //Use Of Serilog
            this._logger = logger;
            _logger.LogInformation("UserController Logs:");
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
        /// Gets User Entity by ParentId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetLookup(string id)
        {
            var result = await Mediator.Send(new GetUsersByParentId { Id = id });
            return Ok(result);
        }
        /// <summary>
        /// Gets User Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetUserById { Id = id });
            return Ok(new Response<GetUserDto>(result));
        }

    }
}
