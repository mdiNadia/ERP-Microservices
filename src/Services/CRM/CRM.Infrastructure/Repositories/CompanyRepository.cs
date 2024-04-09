using CRM.Application.Interfaces;
using CRM.Domain.Entities.LeadManagement;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ICRMDbContext context) : base(context)
        {
        }
    }
}
