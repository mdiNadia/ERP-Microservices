using CRM.Application.Interfaces;
using CRM.Domain.Enums;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;



namespace CRM.Application.Features.LeadManagement.CompanyIndustry.Commands
{
    public class CreateCompanyIndustry : IRequest<int>
    {
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string LatinTitle { get; set; }
        public class CreateCompanyIndustryHandler : IRequestHandler<CreateCompanyIndustry, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateCompanyIndustryHandler(IUnitOfWork unitOfWork)
            {
                this._unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateCompanyIndustry command, CancellationToken cancellationToken)
            {
                var entity = command.Adapt<Domain.Entities.LeadManagement.CompanyIndustry>();
                _unitOfWork.CompanyIndustry.Insert(entity);
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

