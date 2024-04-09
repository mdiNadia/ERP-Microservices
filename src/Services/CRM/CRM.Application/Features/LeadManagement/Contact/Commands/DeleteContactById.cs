using Common.Infrastructure.Services.Errors;
using CRM.Application.Interfaces;
using MediatR;
using System.Net;

namespace CRM.Application.Features.LeadManagement.Contact.Commands
{
    public class DeleteContactById : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteContactByIdHandler : IRequestHandler<DeleteContactById, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteContactByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteContactById command, CancellationToken cancellationToken)
            {

                var entity = await _unitOfWork.Contact.GetByID(command.Id);
                if (entity == null) throw new RestException(HttpStatusCode.BadRequest, "doesn't exists!");
                _unitOfWork.Contact.Delete(entity);
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
