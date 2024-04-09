using CRM.Aggregator.Services.LeadManagement;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Controllers.v1
{

    public class CompanyTypeController : BaseApiController
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeController(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }
        [HttpGet]
        public async Task<object> GetAll()
        {
            var response = await _companyTypeService.GetAll();
            return response;
        }
    }
}
