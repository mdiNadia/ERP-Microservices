using CRM.Domain.Entities.LeadManagement;
using CRM.Domain.Entities.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface ICampaignRepository : IGenericRepository<Campaign>
    {
    }
}
