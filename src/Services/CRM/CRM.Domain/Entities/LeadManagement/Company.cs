
using Common.Domain.Entities;
using CRM.Domain.Entities.Marketing;
using CRM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities.LeadManagement
{
    public class Company : BaseEntity
    {
        [StringLength(50)]
        public string DomainName { get; set; } = string.Empty;
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [StringLength(50)]
        public string OwnerName { get; set; } = string.Empty;//نام صاحب شرکت از اکانت‌ها باید باشه

        public int IndustryId { get; set; }
        public CompanyIndustry Industry { get; set; }
        public LifecycleStage LifecycleStage { get; set; }
        public Type Type { get; set; }
        public CompanySize CompanySize { get; set; }
        public string LinkedinPage { get; set; }
        public string Desciprion { get; set; }
        public LeadSource ComesFrom { get; set; }

        //public Address CompanyAddress {get;set;}


        public ICollection<ActivityFeed> ActivityFeeds { get; set; }
        public ICollection<CompanyCall> CompanyCalls { get; set; }
        public ICollection<CompanyContact> CompanyContacts { get; set; }
        public ICollection<CompanyOpportunity> CompanyOpportunities { get; set; }//Deals


        public ICollection<ListOfCompany> ListOfCompanies { get; set; }
        public ICollection<CampaignMember> CampaignMembers { get; set; }


    }
}