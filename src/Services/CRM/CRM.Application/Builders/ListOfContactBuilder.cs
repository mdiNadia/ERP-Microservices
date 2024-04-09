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
    public class ListOfContactBuilder : IEntityTypeConfiguration<ListOfContact>
    {
        public void Configure(EntityTypeBuilder<ListOfContact> builder)
        {
            builder.HasKey(x => new { x.Id, x.ContactId, x.ObjectListId });

            builder.HasOne(x => x.Contact).WithMany(x => x.ListOfContacts)
                .HasForeignKey(x => x.ContactId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ObjectList).WithMany(x => x.ListOfContacts).HasForeignKey(x => x.ObjectListId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
