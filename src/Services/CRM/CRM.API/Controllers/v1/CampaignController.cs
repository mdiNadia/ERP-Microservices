using CRM.API.Filter;
using CRM.API.Helpers;
using CRM.API.Services;
using CRM.API.Wrappers;
using CRM.Application.Features.Marketing.Campaign.Commands;
using CRM.Application.Features.Marketing.Campaign.Queries;
using CRM.Domain.Entities.Marketing;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.v1
{
    //[Authorize(Roles = "User")]
    [ApiVersion("1.0")]
    //[Authorize]
    public class CampaignController : BaseApiController
    {
        private readonly IUriService _uriService;
        private readonly ILogger<CampaignController> _logger;

        public CampaignController(ILogger<CampaignController> logger, IUriService uriService)
        {
            //Use Of Serilog
            this._logger = logger;
            this._uriService = uriService;
            _logger.LogInformation("CampaignController Logs:");
        }
        
        /// <summary>
        /// Creates a New Campaign.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCampaign command)
        {
            command.CreatedBy = "9e287e50-d418-420b-b85b-03a748a31943";
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Campaign with paging filter.
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        //{
        //    var route = Request.Path.Value;
        //    var pagedData = await Mediator.Send(new GetAllCampaigns(filter));
        //    var totalRecords = await Mediator.Send(new GetAllCountCampaigns());
        //    var pagedReponse = PaginationHelper.CreatePagedReponse<Campaign>(pagedData, filter, totalRecords, _uriService, route);
        //    return Ok(pagedReponse);
        //}
        ///////////////////////////////////////////////////////////
        /// <summary>
        /// Gets all Campaign with default DevExtreme paging filter.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetAll(DataSourceLoadOptions loadOptions)
        {
            var result = await Mediator.Send(new GetAllCampaigns());
            return DataSourceLoader.Load(result, loadOptions);
        }
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Gets Campaign Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetCampaignById { Id = id });
            return Ok(new Response<Campaign>(response));
        }
        /// <summary>
        /// Deletes Campaign Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCampaignById { Id = id }));
        }

        /// <summary>
        /// Updates the Campaign Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateCampaign command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


    }
}
