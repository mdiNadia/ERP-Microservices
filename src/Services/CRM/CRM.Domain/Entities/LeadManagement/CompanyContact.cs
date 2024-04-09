using Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    public class CompanyContact:BaseEntity
    {
        public int CompanyId {  get; set; }
        public Company Company { get; set; }
        public int ContactId {  get; set; }
        public Contact Contact { get; set; }
    }
}
