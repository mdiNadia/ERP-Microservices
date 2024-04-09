using CRM.API.Filter;
using CRM.API.Helpers;
using CRM.API.Services;
using CRM.API.Wrappers;
using CRM.Application.Features.LeadManagement.CompanyIndustry.Commands;
using CRM.Application.Features.LeadManagement.CompanyIndustry.Queries;
using CRM.Application.Features.Marketing.Campaign.Queries;
using CRM.Domain.Entities.LeadManagement;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.v1
{
    //[Authorize(Roles = "User")]
    [ApiVersion("1.0")]
    //[Authorize]
    public class CompanyIndustryController : BaseApiController
    {
        private readonly ILogger<CompanyIndustryController> _logger;
        private readonly IUriService _uriService;

        public CompanyIndustryController(ILogger<CompanyIndustryController> logger, IUriService uriService)
        {
            //Use Of Serilog
            this._logger = logger;
            this._uriService = uriService;
            _logger.LogInformation("CompanyIndustryController Logs:");
        }
        
        /// <summary>
        /// Creates a New CompanyService.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyIndustry command)
        {
            command.CreatedBy = "9e287e50-d418-420b-b85b-03a748a31943";
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all CompanyService with paging filter.
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        //{
        //    var route = Request.Path.Value;
        //    var pagedData = await Mediator.Send(new GetAllCompanyIndustries(filter));
        //    var totalRecords = await Mediator.Send(new GetAllCountCompanyIndustries());
        //    var pagedReponse = PaginationHelper.CreatePagedReponse<CompanyIndustry>(pagedData, filter, totalRecords, _uriService, route);
        //    return Ok(pagedReponse);
        //}
        ///////////////////////////////////////////////////////////
        /// <summary>
        /// Gets all CompanyService with default DevExtreme paging filter.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetAll(DataSourceLoadOptions loadOptions)
        {
            var result = await Mediator.Send(new GetAllCompanyIndustries());
            return DataSourceLoader.Load(result, loadOptions);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetLookup()
        {
            var response = await Mediator.Send(new LookupCompanyIndustries());
            return Ok(response);
        }
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Gets CompanyService Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetCompanyIndustryById { Id = id });
            return Ok(new Response<CompanyIndustry>(response));
        }
        /// <summary>
        /// Deletes CompanyService Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCompanyIndustryById { Id = id }));
        }

        /// <summary>
        /// Updates the CompanyService Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateCompanyIndustry command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


    }
}
