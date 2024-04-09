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
    public class CompanyCallBuilder : IEntityTypeConfiguration<CompanyCall>
    {
        public void Configure(EntityTypeBuilder<CompanyCall> builder)
        {
            builder.HasKey(x => new { x.Id, x.CompanyId, x.CallId });

            builder.HasOne(x => x.Call).WithMany(x => x.CompanyCalls)
                .HasForeignKey(x => x.CallId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Company).WithMany(x => x.CompanyCalls).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
