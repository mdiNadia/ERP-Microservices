using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Enums
{
    public enum LifecycleStage
    {
        Subscriber=0,
        Lead =1,
        MarketingQualifiedLead = 2,
        SalesQualifiedLead=3,
        Opportunity=4,
        Customer=5,
        Other=6

    }
}
