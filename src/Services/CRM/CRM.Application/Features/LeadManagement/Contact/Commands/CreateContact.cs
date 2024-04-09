using CRM.Application.Interfaces;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace CRM.Application.Features.LeadManagement.Contact.Commands
{
    public class CreateContact : IRequest<int>
    {
        public string CreatedBy { get; set; }


        public class CreateContactHandler : IRequestHandler<CreateContact, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateContactHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateContact command, CancellationToken cancellationToken)
            {
                var entity = command.Adapt<Domain.Entities.LeadManagement.Contact>();
                _unitOfWork.Contact.Insert(entity);
                try
                {
                    await _unitOfWork.CompleteAsync();
                    return entity.Id;
                }
                catch (Exception err) { throw new Exception("Error occured in saving data in database!"); }
            }
        }
    }
}

