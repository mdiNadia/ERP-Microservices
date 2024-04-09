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
    public class CompanyOpportunityBuilder : IEntityTypeConfiguration<CompanyOpportunity>
    {
        public void Configure(EntityTypeBuilder<CompanyOpportunity> builder)
        {
            builder.HasKey(x => new { x.Id, x.CompanyId, x.OpportunityId });

            builder.HasOne(x => x.Opportunity).WithMany(x => x.CompanyOpportunities)
                .HasForeignKey(x => x.OpportunityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Company).WithMany(x => x.CompanyOpportunities).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
