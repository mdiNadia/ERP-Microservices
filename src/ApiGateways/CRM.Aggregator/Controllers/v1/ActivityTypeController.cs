using CRM.Aggregator.Services.LeadManagement;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Controllers.v1
{

    public class ActivityTypeController : BaseApiController
    {
        private readonly IActivityTypeService _activityTypeService;

        public ActivityTypeController(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
        }
        [HttpGet]
        public async Task<object> GetAll()
        {
            var response = await _activityTypeService.GetAll();
            return response;
        }
    }
}
