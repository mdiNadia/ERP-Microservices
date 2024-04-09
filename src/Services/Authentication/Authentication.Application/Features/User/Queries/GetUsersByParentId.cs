using Authentication.Application.Interfaces;
using Authentication.Application.Models.Common;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Application.Features.User.Queries
{
    public class GetUsersByParentId : IRequest<IEnumerable<GetLookupDto>>
    {
        public string Id { get; set; }
        public class GetUsersByParentIdHandler : IRequestHandler<GetUsersByParentId, IEnumerable<GetLookupDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetUsersByParentIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<GetLookupDto>> Handle(GetUsersByParentId query, CancellationToken cancellationToken)
            {
                var users = await _unitOfWork.ApplicationUsers.GetQueryList()
                    .Where(c=>c.Id == query.Id).Select(c=>new GetLookupDto
                    {
                         Id = c.Id,
                         Name = c.FirstName +" "+ c.LastName,
                         CreationDate = c.CreationDate,
                    }).OrderByDescending(c=>c.CreationDate).ToListAsync();
                if (users == null) return null;
                return users;
            }
        }
    }
}
