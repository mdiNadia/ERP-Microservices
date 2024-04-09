using CRM.Aggregator.Models.Customer;
using CRM.Aggregator.Services.Account;
using CRM.Aggregator.Services.LeadManagement;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Aggregator.Controllers.v1
{

    public class ContactController : BaseApiController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }
        [HttpGet]
        public async Task<object> GetAll()
        {
            var response = await _contactService.GetAll();
            return response;
        }
        [HttpGet("{id}")]
        public async Task<object> GetById(int id)
        {
            var response = await _contactService.GetById(id);
            return response;
        }

        [HttpPost]
        public async Task<bool> Create(CreateContact command)
        {
            var response = await _contactService.Create(command);
            return response;
        }
    }
}
