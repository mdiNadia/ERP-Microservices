using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.Features.LeadManagement.Contact.Queries
{
    public class GetAllCountContacts : IRequest<int>
    {
        public class GetAllCountContactsHandler : IRequestHandler<GetAllCountContacts, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllCountContactsHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(GetAllCountContacts query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Contact.GetQueryList().AsNoTracking().CountAsync();
            }
        }
    }
}
