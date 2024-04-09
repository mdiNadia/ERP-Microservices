using Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    public class ListOfContact:BaseEntity
    {
        public int ContactId {  get; set; }
        public Contact Contact { get; set; }

        public int ObjectListId {  get; set; }
        public ObjectList ObjectList { get; set; }
    }
}
