using CRM.Application.Interfaces;
using MediatR;
namespace CRM.Application.Features.LeadManagement.CompanyIndustry.Queries
{
    public class GetCompanyIndustryById : IRequest<CRM.Domain.Entities.LeadManagement.CompanyIndustry>
    {
        public int Id { get; set; }
        public class GetCompanyIndustryByIdHandler : IRequestHandler<GetCompanyIndustryById, CRM.Domain.Entities.LeadManagement.CompanyIndustry>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCompanyIndustryByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<CRM.Domain.Entities.LeadManagement.CompanyIndustry> Handle(GetCompanyIndustryById query, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.CompanyIndustry.GetByID(query.Id);
                if (data == null) return null;
                return data;
            }
        }
    }
}
