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
    public class ListOfCompanyBuilder : IEntityTypeConfiguration<ListOfCompany>
    {
        public void Configure(EntityTypeBuilder<ListOfCompany> builder)
        {

            builder.HasKey(x => new { x.Id, x.CompanyId, x.ObjectListId });

            builder.HasOne(x => x.Company).WithMany(x => x.ListOfCompanies)
                .HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ObjectList).WithMany(x => x.ListOfCompanies).HasForeignKey(x => x.ObjectListId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
