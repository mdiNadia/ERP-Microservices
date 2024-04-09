using Common.Domain.Entities;
using CRM.Domain.Entities.LeadManagement;


namespace CRM.Domain.Entities.Marketing
{
    public class CampaignMember:BaseEntity
    {
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public int? ContactId {  get; set; }
        public Contact Contact { get; set; }
        public int? ComanyId { get; set; }
        public Company Company { get; set; }
    }
}
