using CRM.Application.Interfaces;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CRM.Application.Features.Marketing.Campaign.Queries
{
    public class GetCampaignById : IRequest<CRM.Domain.Entities.Marketing.Campaign>
    {
        public int Id { get; set; }
        public class GetCampaignByIdHandler : IRequestHandler<GetCampaignById, CRM.Domain.Entities.Marketing.Campaign>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCampaignByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<CRM.Domain.Entities.Marketing.Campaign> Handle(GetCampaignById query, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.Campaign.GetByID(query.Id);
                if (data == null) return null;
                return data;
            }
        }
    }
}
