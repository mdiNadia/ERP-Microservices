using Common.Domain.Entities;
using CRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    public class ObjectList:BaseEntity
    {
        [StringLength(50)]
        public string Name {  get; set; }

        public string Description { get; set; }
        public ListType Type {  get; set; }
        public ListBased ListBased { get; set; }

        public ICollection<ListOfContact> ListOfContacts { get; set; }
        public ICollection<ListOfCompany> ListOfCompanies { get; set; }
        public ICollection<ListOfOpportunity> ListOfOpportunities { get; set; }


    }
}
