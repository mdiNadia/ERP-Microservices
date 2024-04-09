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
    public class ListOfOpportunityBuilder : IEntityTypeConfiguration<ListOfOpportunity>
    {
        public void Configure(EntityTypeBuilder<ListOfOpportunity> builder)
        {
            builder.HasKey(x => new { x.Id, x.OpportunityId, x.ObjectListId });
            builder.HasOne(x => x.Opportunity).WithMany(x => x.ListOfOpportunities)
                .HasForeignKey(x => x.OpportunityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ObjectList).WithMany(x => x.ListOfOpportunities).HasForeignKey(x => x.ObjectListId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
