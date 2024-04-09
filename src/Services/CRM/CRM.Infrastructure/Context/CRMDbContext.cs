



using CRM.Application.Builders;
using CRM.Application.Interfaces;
using CRM.Domain.Entities.LeadManagement;
using CRM.Domain.Entities.Marketing;
using CRM.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Emit;

namespace CRM.Infrastructure.Context
{
    public class CRMDbContext : DbContext, ICRMDbContext
    {
 

        public CRMDbContext(DbContextOptions<CRMDbContext> options)
            : base(options)
        {

        }



        public DbSet<ActivityFeed> ActivityFeeds { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyCall> CompaniesCalls { get; set; }
        public DbSet<CompanyContact> CompaniesContacts { get; set; }
        public DbSet<CompanyIndustry> CompanyIndustries { get; set; }
        public DbSet<CompanyOpportunity> CompaniesOpportunities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCall> ContactsCalls { get; set; }
        public DbSet<ContactOpportunity> ContactsOpportunities { get; set; }
        public DbSet<ListOfCompany> ListOfCompanies { get; set; }
        public DbSet<ListOfContact> ListOfContacts { get; set; }
        public DbSet<ListOfOpportunity> ListOfOpportunities { get; set; }
        public DbSet<ObjectList> ObjectList { get; set; }
        public DbSet<OpportunityCall> OpportunitiesCalls { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignMember> CampaignMembers { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Product> Products { get; set; }


        public IDbContextTransaction DatabaseBeginTransaction() { return Database.BeginTransaction(); }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.ApplyConfiguration<Company>(new CompanyBuilder());
            builder.ApplyConfiguration<ActivityFeed>(new ActivityFeedBuilder());
            //builder.ApplyConfiguration<Product>(new ProductBuilder());
            //builder.ApplyConfiguration<CampaignMember>(new CampaignMemberBuilder());
            //builder.ApplyConfiguration<CompanyCall>(new CompanyCallBuilder());
            //builder.ApplyConfiguration<CompanyContact>(new CompanyContactBuilder());
            //builder.ApplyConfiguration<CompanyOpportunity>(new CompanyOpportunityBuilder());
            //builder.ApplyConfiguration<ContactCall>(new ContactCallBuilder());
            //builder.ApplyConfiguration<ContactOpportunity>(new ContactOpportunityBuilder());
            //builder.ApplyConfiguration<ListOfCompany>(new ListOfCompanyBuilder());
            //builder.ApplyConfiguration<ListOfContact>(new ListOfContactBuilder());
            //builder.ApplyConfiguration<ListOfOpportunity>(new ListOfOpportunityBuilder());
            //builder.ApplyConfiguration<OpportunityCall>(new OpportunityCallBuilder());
            //builder.ApplyConfiguration<Contact>(new ContactBuilder());


            base.OnModelCreating(builder);
        }


        public DbSet<TEntity> set<TEntity>() where TEntity : class { return Set<TEntity>(); }

        Task ICRMDbContext.SaveChangesAsync()
        {
            return SaveChangesAsync();
        }
    }
}
