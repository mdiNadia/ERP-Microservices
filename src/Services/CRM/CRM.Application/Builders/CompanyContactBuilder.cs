using CRM.Domain.Entities.LeadManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Builders
{
    public class CompanyContactBuilder : IEntityTypeConfiguration<CompanyContact>
    {
        public void Configure(EntityTypeBuilder<CompanyContact> builder)
        {
            builder.HasKey(x => new { x.Id, x.CompanyId, x.ContactId });


            builder.HasOne(x => x.Contact).WithMany(x => x.CompanyContacts)
                .HasForeignKey(x => x.ContactId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Company).WithMany(x => x.CompanyContacts).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
