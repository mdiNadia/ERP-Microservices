using Authentication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Interfaces
{
    public interface IApplicationRoleRepository : IGenericRepository<ApplicationRole>
    {
    }
}
