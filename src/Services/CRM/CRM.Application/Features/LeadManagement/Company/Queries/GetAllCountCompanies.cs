using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.Features.LeadManagement.Company.Queries
{
    public class GetAllCountCompanies : IRequest<int>
    {
        public class GetAllCountCompaniesHandler : IRequestHandler<GetAllCountCompanies, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllCountCompaniesHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(GetAllCountCompanies query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Company.GetQueryList().AsNoTracking().CountAsync();
            }
        }
    }
}
