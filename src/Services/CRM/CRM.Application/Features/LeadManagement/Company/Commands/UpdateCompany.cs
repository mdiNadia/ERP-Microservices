using CRM.Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.LeadManagement.Company.Commands
{
    public class UpdateCompany : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public class UpdateCmpanyHandler : IRequestHandler<UpdateCompany, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UpdateCmpanyHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateCompany command, CancellationToken cancellationToken)
            {
                var entity = await _unitOfWork.Company.GetByID(command.Id);

                if (entity == null)
                {
                    return default;
                }
                else
                {

                    //
                    _unitOfWork.Company.Update(entity);
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
