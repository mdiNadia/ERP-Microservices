using CRM.Aggregator.Models.Marketing;
using CRM.Aggregator.Services.Marketing;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Controllers.v1
{

    public class CampaignTypeController : BaseApiController
    {
        private readonly ICampaignTypeService _campaignTypeService;

        public CampaignTypeController(ICampaignTypeService campaignTypeService)
        {
            _campaignTypeService = campaignTypeService;
        }
        [HttpGet]
        public async Task<object> GetAll()
        {
            var response = await _campaignTypeService.GetAll();
            return response;
        }
        [HttpGet("[action]")]
        public async Task<List<GetLookup<int>>> GetLookup()
        {
            var response = await _campaignTypeService.GetLookup();
            return response;
        }
        [HttpGet("{id}")]
        public async Task<object> GetById(int id)
        {
            var response = await _campaignTypeService.GetById(id);
            return response;
        }

        [HttpPost]
        public async Task<bool> Create(CreateCampaignType command)
        {
            var response = await _campaignTypeService.Create(command);
            return response;
        }

    }
}
