using Common.Domain.Entities;
using CRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities.LeadManagement
{
    //نوع فعالیت//
    //شرکت خدمات مهاجرتی
    //شرکت مهندسی نرم افزار
    //آرایشگاه
    public class CompanyIndustry:BaseEntity
    {

        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string LatinTitle { get; set; }

        public ICollection<Company> Companies { get; set; }

    }
}
