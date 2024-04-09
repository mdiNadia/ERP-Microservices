using Authentication.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Application.Features.User.Queries
{
    public class GetAllCountUsers : IRequest<int>
    {
        public class GetAllCountUsersHandler : IRequestHandler<GetAllCountUsers, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllCountUsersHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(GetAllCountUsers query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.ApplicationUsers.GetQueryList().AsNoTracking().CountAsync();
            }
        }
    }
}
