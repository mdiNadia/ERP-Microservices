using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using CRM.Domain.Entities.LeadManagement;

namespace CRM.Application.Builders
{
    public class ActivityFeedBuilder : IEntityTypeConfiguration<ActivityFeed>
    {
        public void Configure(EntityTypeBuilder<ActivityFeed> builder)
        {

            builder.HasOne(x => x.Contact).WithMany(x => x.ActivityFeeds)
                .HasForeignKey(x => x.ContactId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Company).WithMany(x => x.ActivityFeeds).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Call).WithOne(x => x.ActivityFeed).HasForeignKey<ActivityFeed>(x => x.CallId).OnDelete(DeleteBehavior.Restrict);

        }
    }

}
