
using Common.Domain.Entities;
using CRM.Domain.Entities.Marketing;
using CRM.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace CRM.Domain.Entities.LeadManagement
{
    public class Contact : BaseEntity
    {
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;
        [StringLength(225)]
        public string Email { get; set; } = string.Empty;
        [StringLength(225)]
        public string  JobTitle{ get; set; } = string.Empty;
        public string OwnerId { get; set; }//who should be in touch with this Contact//حتما از کسایی که اکانت داره باید باشه
        public string AccountId { get; set; }
        public LifecycleStage LifecycleStage { get; set; }
        public LeadStatus Status { get; set; }
        public LeadSource ComesFrom { get; set; }


        public ICollection<ActivityFeed> ActivityFeeds { get; set; } = new List<ActivityFeed>();
        public ICollection<ContactCall> ContactCalls { get; set; }
        public ICollection<CompanyContact> CompanyContacts { get; set; }
        public ICollection<ContactOpportunity> ContactOpportunities { get; set; }//Deals

        public ICollection<ListOfContact> ListOfContacts { get; set; }
        public ICollection<CampaignMember> CampaignMembers { get; set; }


    }
}
