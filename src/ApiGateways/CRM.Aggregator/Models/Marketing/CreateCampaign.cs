using CRM.Aggregator.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRM.Aggregator.Models.Marketing
{
    public class CreateCampaign
    {
        public string CreatedBy { get; set; }
        [StringLength(225)]
        public string Name { get; set; } = string.Empty;
        public int CampaignTypeId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public int Status { get; set; }//خودکار مقدار باید بگیرد
        public string Sponsor { get; set; }
        public decimal BudgetCost { get; set; }//The budget amount for spending on the campaign 
        public decimal ActualCost { get; set; } //The actual amount spent on the campaign
        public decimal ExpectedRevenue { get; set; }//The amount of revenue expected from the campaign
        public decimal ActualRevenue { get; set; }//The amount of revenue expected from the campaign

        public int ExpectedResponse { get; set; }//خودکار مقدار باید بگیرد
        public int ExpectedSalesCount { get; set; }//The number of sales that you expect to make from the campaign
        public int ActualSalesCount { get; set; }
        public int ExpectedResponseCount { get; set; }//The number of responses expected from the target audience
        public int ActualResponseCount { get; set; }//The actual number of responses received from the target audience


        public string Description { get; set; } = string.Empty;
        public string OwnerId { get; set; }//who should be in touch with this campagin
    }
}
