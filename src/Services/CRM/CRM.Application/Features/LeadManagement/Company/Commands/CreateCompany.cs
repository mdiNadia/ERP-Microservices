using CRM.Application.Interfaces;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace CRM.Application.Features.LeadManagement.Company.Commands
{
    public class CreateCompany : IRequest<int>
    {
        public string CreatedBy { get; set; } 
       


        public class CreateCompanyHandler : IRequestHandler<CreateCompany, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateCompanyHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateCompany command, CancellationToken cancellationToken)
            {
                var entity = command.Adapt<Domain.Entities.LeadManagement.Company>();
                _unitOfWork.Company.Insert(entity);
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

