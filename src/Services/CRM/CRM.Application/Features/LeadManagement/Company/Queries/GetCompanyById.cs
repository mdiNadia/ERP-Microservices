using CRM.Application.Interfaces;
using MediatR;

namespace CRM.Application.Features.LeadManagement.Company.Queries
{
    public class GetCompanyById : IRequest<CRM.Domain.Entities.LeadManagement.Company>
    {
        public int Id { get; set; }
        public class GetCompanyByIdHandler : IRequestHandler<GetCompanyById, CRM.Domain.Entities.LeadManagement.Company>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCompanyByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<CRM.Domain.Entities.LeadManagement.Company> Handle(GetCompanyById query, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.Company.GetByID(query.Id);
                if (data == null) return null;
                return data;
            }
        }
    }
}
