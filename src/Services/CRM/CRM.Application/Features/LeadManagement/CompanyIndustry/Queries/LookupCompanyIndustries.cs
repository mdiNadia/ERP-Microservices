using CRM.Application.Dtos.Common;
using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CRM.Application.Features.LeadManagement.CompanyIndustry.Queries
{
    public class LookupCompanyIndustries : IRequest<IEnumerable<GetLookupDto>>
    {
        public LookupCompanyIndustries()
        {
        }
        public class LookupCompanyIndustriesHandler : IRequestHandler<LookupCompanyIndustries, IEnumerable<GetLookupDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public LookupCompanyIndustriesHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<GetLookupDto>> Handle(LookupCompanyIndustries query, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.CompanyIndustry.GetQueryList().Select(c => new GetLookupDto
                {
                    Id = c.Id,
                    Name = c.Title,
                    CreationDate = c.CreationDate
                }).OrderByDescending(c => c.CreationDate).ToListAsync();
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
