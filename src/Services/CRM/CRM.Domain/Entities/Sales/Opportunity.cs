
using Common.Domain.Entities;
using CRM.Domain.Entities.LeadManagement;
using CRM.Domain.Entities.Marketing;
using System.ComponentModel.DataAnnotations;

namespace CRM.Domain.Entities.Sales
{
    //Deal
    public class Opportunity : BaseEntity
    {


        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        [StringLength(50)]
        public string Stage { get; set; } = string.Empty;
        public decimal Value { get;  set; }
        public DateTime CloseDate { get;  set; }

        public int ProductId { get;  set; }
        public Product Product { get;  set; } = new Product();
        public string AccountId { get; set; }



        public ICollection<ContactOpportunity> ContactOpportunities { get; set; }
        public ICollection<OpportunityCall> OpportunityCalls { get; set;}
        public ICollection<CompanyOpportunity> CompanyOpportunities { get; set; }


        public ICollection<ListOfOpportunity> ListOfOpportunities { get; set; }



    }
}
