using CRM.Application.Interfaces;
using MediatR;

namespace CRM.Application.Features.LeadManagement.Contact.Queries
{
    public class GetContactById : IRequest<Domain.Entities.LeadManagement.Contact>
    {
        public int Id { get; set; }
        public class GetContactByIdHandler : IRequestHandler<GetContactById, Domain.Entities.LeadManagement.Contact>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetContactByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Domain.Entities.LeadManagement.Contact> Handle(GetContactById query, CancellationToken cancellationToken)
            {
                var data = await _unitOfWork.Contact.GetByID(query.Id);
                if (data == null) return null;
                return data;
            }
        }
    }
}
