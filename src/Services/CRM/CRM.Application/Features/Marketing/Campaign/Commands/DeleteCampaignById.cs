using Common.Infrastructure.Services.Errors;
using CRM.Application.Interfaces;
using MediatR;
using System.Net;

namespace CRM.Application.Features.Marketing.Campaign.Commands
{
    public class DeleteCampaignById : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCampaignByIdHandler : IRequestHandler<DeleteCampaignById, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCampaignByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(DeleteCampaignById command, CancellationToken cancellationToken)
            {

                var entity = await _unitOfWork.Campaign.GetByID(command.Id);
                if (entity == null) throw new RestException(HttpStatusCode.BadRequest, "Lead doesn't exists!");
                _unitOfWork.Campaign.Delete(entity);
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
