using Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    public class ContactCall:BaseEntity
    {
        public int CallId {  get; set; }
        public Call Call { get; set; }
        public int ContactId {  get; set; }
        public Contact Contact { get; set; }

    }
}
