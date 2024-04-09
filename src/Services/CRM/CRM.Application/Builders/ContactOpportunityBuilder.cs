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
    public class ContactOpportunityBuilder : IEntityTypeConfiguration<ContactOpportunity>
    {
        public void Configure(EntityTypeBuilder<ContactOpportunity> builder)
        {
            builder.HasKey(x => new { x.Id, x.ContactId, x.OpportunityId });

            builder.HasOne(x => x.Opportunity).WithMany(x => x.ContactOpportunities)
                .HasForeignKey(x => x.OpportunityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Contact).WithMany(x => x.ContactOpportunities).HasForeignKey(x => x.ContactId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
