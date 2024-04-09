using Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    public class CompanyCall:BaseEntity
    {
        public int CallId {  get; set; }
        public Call Call { get; set; }

        public int CompanyId {  get; set; }
        public Company Company { get; set; }
    }
}
