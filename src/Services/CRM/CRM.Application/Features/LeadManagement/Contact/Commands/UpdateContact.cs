using CRM.Application.Interfaces;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.LeadManagement.Contact.Commands
{
    public class UpdateContact : IRequest<int>
    {
        public int Id { get; set; }

        public class UpdateContactHandler : IRequestHandler<UpdateContact, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UpdateContactHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateContact command, CancellationToken cancellationToken)
            {
                var entity = await _unitOfWork.Contact.GetByID(command.Id);

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    //updatedFields
                    _unitOfWork.Contact.Update(entity);
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
}
