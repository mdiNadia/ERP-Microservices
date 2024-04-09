using System.ComponentModel.DataAnnotations;

namespace CRM.Aggregator.Models.Marketing
{
    public class CreateCampaignType
    {
        [StringLength(225)]
        public string Name { get; set; }
        [StringLength(225)]
        public string LatinName { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
