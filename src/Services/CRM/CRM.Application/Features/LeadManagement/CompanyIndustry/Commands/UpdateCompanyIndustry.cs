using CRM.Application.Interfaces;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Features.LeadManagement.CompanyIndustry.Commands
{
    public class UpdateCompanyIndustry : IRequest<int>
    {
        public int Id { get; set; }

        public class UpdateCompanyIndustryHandler : IRequestHandler<UpdateCompanyIndustry, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UpdateCompanyIndustryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateCompanyIndustry command, CancellationToken cancellationToken)
            {
                var entity = await _unitOfWork.CompanyIndustry.GetByID(command.Id);

                if (entity == null)
                {
                    return default;
                }
                else
                {
                    //
                    _unitOfWork.CompanyIndustry.Update(entity);
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
