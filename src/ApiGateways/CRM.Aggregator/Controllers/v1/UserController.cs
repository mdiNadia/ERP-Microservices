using CRM.Aggregator.Models;
using CRM.Aggregator.Models.Marketing;
using CRM.Aggregator.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Controllers.v1
{

    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<object> GetAll()
        {
            var response = await _userService.GetAll();
            return response;
        }
        [HttpGet("[action]/{id}")]
        public async Task<List<GetLookup<string>>> GetLookup(string id)
        {
            var response = await _userService.GetLookupByParentId(id);
            return response;
        }
    }
}
