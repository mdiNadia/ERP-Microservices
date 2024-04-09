using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CRM.Application.Features.LeadManagement.Company.Queries
{
    public class GetAllCompanies : IRequest<IQueryable<CRM.Domain.Entities.LeadManagement.Company>>
    {
        public GetAllCompanies()
        {
           
        }
        public class GetAllCompaniesHandler : IRequestHandler<GetAllCompanies, IQueryable<CRM.Domain.Entities.LeadManagement.Company>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllCompaniesHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IQueryable<CRM.Domain.Entities.LeadManagement.Company>> Handle(GetAllCompanies query, CancellationToken cancellationToken)
            {
                var data =  _unitOfWork.Company.GetQueryList().OrderByDescending(c=>c.CreationDate);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
