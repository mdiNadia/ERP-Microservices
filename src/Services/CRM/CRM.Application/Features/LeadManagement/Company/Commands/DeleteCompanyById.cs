using Common.Infrastructure.Services.Errors;
using CRM.Application.Interfaces;
using MediatR;
using System.Net;

namespace CRM.Application.Features.LeadManagement.Company.Commands
{
    public class DeleteCompanyById : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCompanyByIdHandler : IRequestHandler<DeleteCompanyById, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCompanyByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteCompanyById command, CancellationToken cancellationToken)
            {

                var entity = await _unitOfWork.Company.GetByID(command.Id);
                if (entity == null) throw new RestException(HttpStatusCode.BadRequest, "Lead doesn't exists!");
                _unitOfWork.Company.Delete(entity);
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
