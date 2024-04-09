using CRM.Application.Interfaces;
using CRM.Domain.Enums;
using Mapster;
using MediatR;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;



namespace CRM.Application.Features.Marketing.Campaign.Commands
{
    public class CreateCampaign : IRequest<int>
    {
        public string CreatedBy { get; set; }
        [StringLength(225)]
        public string Name { get; set; } = string.Empty;
        public int CampaignTypeId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public CampaignStatus Status { get; set; }
        public string Sponsor { get; set; }
        public decimal BudgetCost { get; set; }//The budget amount for spending on the campaign 
        public decimal ActualCost { get; set; } //The actual amount spent on the campaign
        public decimal ExpectedRevenue { get; set; }//The amount of revenue expected from the campaign
        public CampaignExpectedResponse ExpectedResponse { get; set; }//The response expected from the target audience
        public int ExpectedSalesCount { get; set; }//The number of sales that you expect to make from the campaign
        public int ActualSalesCount { get; set; }
        public int ExpectedResponseCount { get; set; }//The number of responses expected from the target audience
        public int ActualResponseCount { get; set; }//The actual number of responses received from the target audience


        public string Description { get; set; } = string.Empty;
        public string OwnerId { get; set; }//who should be in touch with this campagin



        public class CreateCampaignHandler : IRequestHandler<CreateCampaign, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateCampaignHandler(IUnitOfWork unitOfWork)
            {
                this._unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateCampaign command, CancellationToken cancellationToken)
            {
                var entity = command.Adapt<Domain.Entities.Marketing.Campaign>();
                entity.StartDate = DateTime.Parse(command.StartDate);
                entity.EndDate = DateTime.Parse(command.EndDate);

                _unitOfWork.Campaign.Insert(entity);
                try
                {
                    await _unitOfWork.CompleteAsync();
                    return entity.Id;
                }
                catch (Exception err) { throw new Exception("Error occured in saving data in database!"); }
            }
        }
    }
}

