using CRM.Application.Interfaces;
using CRM.Domain.Entities.LeadManagement;
using CRM.Domain.Entities.Marketing;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class CampaignRepository : GenericRepository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(ICRMDbContext context) : base(context)
        {
        }
    }
}
