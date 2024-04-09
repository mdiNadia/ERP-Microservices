using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CRM.Application.Features.LeadManagement.CompanyIndustry.Queries
{
    public class GetAllCompanyIndustries : IRequest<IQueryable<CRM.Domain.Entities.LeadManagement.CompanyIndustry>>
    {
        public GetAllCompanyIndustries()
        {
           
        }
        public class GetAllCompanyIndustriesHandler : IRequestHandler<GetAllCompanyIndustries, IQueryable<CRM.Domain.Entities.LeadManagement.CompanyIndustry>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllCompanyIndustriesHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IQueryable<CRM.Domain.Entities.LeadManagement.CompanyIndustry>> Handle(GetAllCompanyIndustries query, CancellationToken cancellationToken)
            {
                var data = _unitOfWork.CompanyIndustry.GetQueryList().OrderByDescending(c => c.CreationDate);
                   
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
