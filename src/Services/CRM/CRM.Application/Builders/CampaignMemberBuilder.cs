using CRM.Domain.Entities.LeadManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Domain.Entities.Marketing;

namespace CRM.Application.Builders
{
    public class CampaignMemberBuilder : IEntityTypeConfiguration<CampaignMember>
    {
        public void Configure(EntityTypeBuilder<CampaignMember> builder)
        {

            builder.HasOne(x => x.Campaign).WithMany(x => x.CampaignMembers)
                .HasForeignKey(x => x.CampaignId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Company).WithMany(x => x.CampaignMembers).HasForeignKey(x => x.ComanyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Contact).WithMany(x => x.CampaignMembers)
           .HasForeignKey(x => x.ContactId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
