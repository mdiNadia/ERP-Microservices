using CRM.API.Filter;
using CRM.API.Helpers;
using CRM.API.Services;
using CRM.API.Wrappers;
using CRM.Application.Features.LeadManagement.Contact.Commands;
using CRM.Application.Features.LeadManagement.Contact.Queries;
using CRM.Domain.Entities.LeadManagement;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.v1
{
    //[Authorize(Roles = "User")]
    [ApiVersion("1.0")]
    //[Authorize]
    public class ContactController : BaseApiController
    {
        private readonly IUriService _uriService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger, IUriService uriService)
        {
            //Use Of Serilog
            this._logger = logger;
            this._uriService = uriService;
            _logger.LogInformation("ContactController Logs:");
        }
        
        /// <summary>
        /// Creates a New Contact.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateContact command)
        {
            command.CreatedBy = "9e287e50-d418-420b-b85b-03a748a31943";
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Contact with paging filter.
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        //{
        //    var route = Request.Path.Value;
        //    var pagedData = await Mediator.Send(new GetAllContacts(filter));
        //    var totalRecords = await Mediator.Send(new GetAllCountContacts());
        //    var pagedReponse = PaginationHelper.CreatePagedReponse<Contact>(pagedData, filter, totalRecords, _uriService, route);
        //    return Ok(pagedReponse);
        //}
        ///////////////////////////////////////////////////////////
        /// <summary>
        /// Gets all Contact with default DevExtreme paging filter.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetAll(DataSourceLoadOptions loadOptions)
        {
            var result = await Mediator.Send(new GetAllContacts());
            return DataSourceLoader.Load(result, loadOptions);
        }
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Gets Contact Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetContactById { Id = id });
            return Ok(new Response<Contact>(response));
        }
        /// <summary>
        /// Deletes Contact Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteContactById { Id = id }));
        }

        /// <summary>
        /// Updates the Contact Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update(int id, UpdateContact command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}


    }
}
