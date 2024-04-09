using Common.Domain.Entities;
using CRM.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    public class Call:BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public string ActivityAssignedTo {  get; set; }
        public DateTime ActivityDate { get; set; }

        public string CallNotes { get; set; }
        

        public ICollection<ContactCall> ContactCalls { get; set; }
        public ICollection<CompanyCall> CompanyCalls { get; set; }
        public ICollection<OpportunityCall> OpportunityCalls { get; set; }//Opportunity
        //call outcome


        public int ActivityFeedId {  get; set; }//calls
        public ActivityFeed ActivityFeed { get; set; }
    }
}
