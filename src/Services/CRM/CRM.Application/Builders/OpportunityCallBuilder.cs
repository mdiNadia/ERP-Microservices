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
    public class OpportunityCallBuilder : IEntityTypeConfiguration<OpportunityCall>
    {
        public void Configure(EntityTypeBuilder<OpportunityCall> builder)
        {
            builder.HasKey(x => new { x.Id, x.OpportunityId, x.CallId });
            builder.HasOne(x => x.Opportunity).WithMany(x => x.OpportunityCalls)
                .HasForeignKey(x => x.OpportunityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Call).WithMany(x => x.OpportunityCalls).HasForeignKey(x => x.CallId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
