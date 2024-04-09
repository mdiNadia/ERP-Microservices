using Common.Domain.Entities;
using CRM.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    public class ContactOpportunity:BaseEntity
    {
        public int ContactId {  get; set; }
        public Contact Contact {  get; set; }
        public int OpportunityId {  get; set; }
        public Opportunity Opportunity { get; set; }
    }
}
