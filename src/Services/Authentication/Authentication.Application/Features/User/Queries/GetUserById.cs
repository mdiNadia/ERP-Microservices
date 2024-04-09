using Authentication.Application.Interfaces;
using Mapster;
using MediatR;

namespace Authentication.Application.Features.User.Queries
{
    public class GetUserById : IRequest<GetUserDto>
    {
        public int Id { get; set; }
        public class GetUserByIdHandler : IRequestHandler<GetUserById, GetUserDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetUserByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<GetUserDto> Handle(GetUserById query, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.ApplicationUsers.GetByID(query.Id);
                if (user == null) return null;
                return user.Adapt<GetUserDto>();
            }
        }
    }
}
