
using CRM.API.Services;
using CRM.API.Wrappers;
using CRM.Application.Features.LeadManagement.Company.Commands;
using CRM.Application.Features.LeadManagement.Company.Queries;
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
    public class CompanyController : BaseApiController
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IUriService _uriService;

        public CompanyController(ILogger<CompanyController> logger, IUriService uriService)
        {
            //Use Of Serilog
            this._logger = logger;
            this._uriService = uriService;
            _logger.LogInformation("CompanyController Logs:");
        }
        
        /// <summary>
        /// Creates a New Company.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompany command)
        {
            command.CreatedBy = "9e287e50-d418-420b-b85b-03a748a31943";
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Company with paging filter.
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        //{
        //    var route = Request.Path.Value;
        //    var pagedData = await Mediator.Send(new GetAllCompanies(filter));
        //    var totalRecords = await Mediator.Send(new GetAllCountCompanies());
        //    var pagedReponse = PaginationHelper.CreatePagedReponse<Company>(pagedData, filter, totalRecords, _uriService, route);
        //    return Ok(pagedReponse);
        //}
        ///////////////////////////////////////////////////////////
        /// <summary>
        /// Gets all Company with default DevExtreme paging filter.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetAll(DataSourceLoadOptions loadOptions)
        {
            var result = await Mediator.Send(new GetAllCompanies());
            return DataSourceLoader.Load(result, loadOptions);
        }
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Gets Company Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetCompanyById { Id = id });
            return Ok(new Response<Company>(response));
        }
        /// <summary>
        /// Deletes Company Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCompanyById { Id = id }));
        }

        /// <summary>
        /// Updates the Company Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateCompany command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


    }
}
