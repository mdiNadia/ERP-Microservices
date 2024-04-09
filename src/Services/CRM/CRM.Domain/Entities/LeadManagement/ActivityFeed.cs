
using Common.Domain.Entities;
using CRM.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace CRM.Domain.Entities.LeadManagement
{
    //lead, contact or company behavior
    public class ActivityFeed : BaseEntity
    {
        //ActivityType (e.g., email open, form submission,form abandoned, website visits.)
        public ActivityFeedType Type { get; set; }
        public DateTime ActivityDate { get; set; }
        public ActivityFeedStatus Status{get;set;}
        public string Details { get; set; } = string.Empty;


        public int? ContactId { get; set; } 
        public Contact Contact { get;  set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? CallId { get; set;}
        public Call Call { get; set; }

    }
}
