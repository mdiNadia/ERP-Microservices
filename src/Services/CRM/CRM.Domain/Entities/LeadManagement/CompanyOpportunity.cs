using Common.Domain.Entities;
using CRM.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    public class CompanyOpportunity:BaseEntity
    {
        public int CompanyId {  get; set; }
        public Company Company { get; set; }
        public int OpportunityId {  get; set; }
        public Opportunity Opportunity { get; set; }
    }
}
