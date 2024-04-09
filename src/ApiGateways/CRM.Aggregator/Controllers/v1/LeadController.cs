using CRM.Aggregator.Models;
using CRM.Aggregator.Services.LeadManagement;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Controllers.v1
{

    public class LeadController : BaseApiController
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }
        [HttpGet]
        public async Task<object> GetAll()
        {
            var response = await _leadService.GetAll();
            return response;
        }
    }
}
