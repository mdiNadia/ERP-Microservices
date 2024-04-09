using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CRM.Application.Features.Marketing.Campaign.Queries
{
    public class GetAllCampaigns : IRequest<IQueryable<CRM.Domain.Entities.Marketing.Campaign>>
    {
        public GetAllCampaigns()
        {

        }
        public class GetAllCampaignsHandler : IRequestHandler<GetAllCampaigns, IQueryable<CRM.Domain.Entities.Marketing.Campaign>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllCampaignsHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IQueryable<CRM.Domain.Entities.Marketing.Campaign>> Handle(GetAllCampaigns query, CancellationToken cancellationToken)
            {
                var data =  _unitOfWork.Campaign.GetQueryList().OrderByDescending(c => c.CreationDate);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
