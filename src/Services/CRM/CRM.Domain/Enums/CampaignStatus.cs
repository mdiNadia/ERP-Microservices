using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Enums
{
    public enum CampaignStatus
    {
        Planning = 0,
        Draft = 1,
        InProgress = 2,
        Queued = 3,
        Sent = 4,
        Completed = 5,
        Canceled = 6,
        Failed  = 7,
        Active = 8,
        Inactive = 9,
    }
}
