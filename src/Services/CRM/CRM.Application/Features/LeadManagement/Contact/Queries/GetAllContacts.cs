using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CRM.Application.Features.LeadManagement.Contact.Queries
{
    public class GetAllContacts : IRequest<IQueryable<Domain.Entities.LeadManagement.Contact>>
    {
        public GetAllContacts()
        {
        }
        public class GetAllContactsHandler : IRequestHandler<GetAllContacts, IQueryable<Domain.Entities.LeadManagement.Contact>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllContactsHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IQueryable<Domain.Entities.LeadManagement.Contact>> Handle(GetAllContacts query, CancellationToken cancellationToken)
            {
                var data = _unitOfWork.Contact.GetQueryList().OrderByDescending(c => c.CreationDate);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
        }
    }
}
