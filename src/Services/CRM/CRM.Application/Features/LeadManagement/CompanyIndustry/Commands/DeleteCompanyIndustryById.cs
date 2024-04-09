using Common.Infrastructure.Services.Errors;
using CRM.Application.Interfaces;
using MediatR;
using System.Net;

namespace CRM.Application.Features.LeadManagement.CompanyIndustry.Commands
{
    public class DeleteCompanyIndustryById : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCompanyIndustryByIdHandler : IRequestHandler<DeleteCompanyIndustryById, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCompanyIndustryByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteCompanyIndustryById command, CancellationToken cancellationToken)
            {

                var entity = await _unitOfWork.CompanyIndustry.GetByID(command.Id);
                if (entity == null) throw new RestException(HttpStatusCode.BadRequest, "Lead doesn't exists!");
                _unitOfWork.CompanyIndustry.Delete(entity);
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
