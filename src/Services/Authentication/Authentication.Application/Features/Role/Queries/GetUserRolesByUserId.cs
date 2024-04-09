using Authentication.Application.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Features.Role.Queries
{
    public class GetUserRolesByUserId : IRequest<List<UserRoleDto>>
    {
        //UserID
        public string Id { get; set; }
        public class GetUserRolesByUserIdHandler : IRequestHandler<GetUserRolesByUserId, List<UserRoleDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetUserRolesByUserIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<List<UserRoleDto>> Handle(GetUserRolesByUserId query, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.ApplicationUsers.GetByID(query.Id);
                
                if (user == null) return null;
                return user.Adapt<List<UserRoleDto>>();
            }
        }
    }
}
