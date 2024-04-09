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
    public class ContactCallBuilder : IEntityTypeConfiguration<ContactCall>
    {
        public void Configure(EntityTypeBuilder<ContactCall> builder)
        {
            builder.HasKey(x => new { x.Id, x.ContactId, x.CallId });

            builder.HasOne(x => x.Call).WithMany(x => x.ContactCalls)
                .HasForeignKey(x => x.CallId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Contact).WithMany(x => x.ContactCalls).HasForeignKey(x => x.ContactId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
