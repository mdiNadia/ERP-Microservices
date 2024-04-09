using CRM.Aggregator.Models.Marketing;
using CRM.Aggregator.Services;
using CRM.Aggregator.Services.Marketing;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Controllers.v1
{

    public class CampaignController : BaseApiController
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
        [HttpGet]
        public async Task<object> GetAll()
        {
            var response = await _campaignService.GetAll();
            return response;
        }
        [HttpGet("{id}")]
        public async Task<object> GetById(int id)
        {
            var response = await _campaignService.GetById(id);
            return response;
        }

        [HttpPost]
        public async Task<bool> Create(CreateCampaign command)
        {
            var response = await _campaignService.Create(command);
            return response;
        }

    }
}
