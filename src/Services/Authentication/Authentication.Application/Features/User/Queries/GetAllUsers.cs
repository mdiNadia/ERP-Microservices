using Authentication.Application.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Authentication.Application.Features.User.Queries
{
    public class GetAllUsers : IRequest<IQueryable<GetUserDto>>
    {
        public GetAllUsers()
        {
        }
        public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IQueryable<GetUserDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAllUsersHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IQueryable<GetUserDto>> Handle(GetAllUsers query, CancellationToken cancellationToken)
            {
                var users =  _unitOfWork.ApplicationUsers.GetQueryList().OrderByDescending(c => c.CreationDate);

                if (users == null)
                {
                    return null;
                }
                return users.Adapt<IQueryable<GetUserDto>>();
            }
        }
    }
}
