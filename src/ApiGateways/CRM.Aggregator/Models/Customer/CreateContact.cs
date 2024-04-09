using System.ComponentModel.DataAnnotations;

namespace CRM.Aggregator.Models.Customer
{
    public class CreateContact
    {
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;
        [StringLength(225)]
        public string Email { get; set; } = string.Empty;
        public string OwnerId { get; set; }//who should be in touch with this Contact
        public string AccountId { get; set; }
        public string Description { get; set; } = string.Empty;

        public int CompanySize { get; set; }
        //مثلا شرکت مهندسی نرم‌افزار یا آرایشگاه
        public int CompanyTypeId { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public int? LeadId { get; set; }
        public int CampaignId { get; set; } = new int();
    }
}
