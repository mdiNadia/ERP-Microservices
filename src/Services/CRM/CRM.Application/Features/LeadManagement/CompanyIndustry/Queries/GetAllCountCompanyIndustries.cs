using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CRM.Application.Features.LeadManagement.CompanyIndustry.Queries
{
    public class GetAllCountCompanyIndustries : IRequest<int>
    {
        public class GetAllCountCompanyIndustriesHandler : IRequestHandler<GetAllCountCompanyIndustries, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllCountCompanyIndustriesHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(GetAllCountCompanyIndustries query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.CompanyIndustry.GetQueryList().AsNoTracking().CountAsync();
            }
        }
    }
}
