using CRM.Domain.Entities.LeadManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CRM.Application.Builders
{
    public class CompanyBuilder : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.HasOne(x => x.Industry).WithMany(x => x.Companies).HasForeignKey(x => x.IndustryId).OnDelete(DeleteBehavior.Restrict);
            //builder.OwnsOne(x => x.CompanyAddress, o =>
            //{
            //    o.ToTable("CompaniesAddress");
            //    o.WithOwner().HasForeignKey("CompanyId");
            //    o.Property<int>("Id");
            //    o.HasKey("Id");
            //    o.Property(x => x.City).HasColumnName("City");
            //    o.Property(x => x.State).HasColumnName("State");
            //    o.Property(x => x.Country).HasColumnName("Country");
            //    o.Property(x => x.Street).HasColumnName("Street");
            //    o.Property(x => x.ZipCode).HasColumnName("ZipCode");
            //    o.Property(x => x.IsCurrentAddress).HasColumnName("IsCurrentAddress");

            //});


        }
    }
}
