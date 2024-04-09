using CRM.Domain.Entities.LeadManagement;
using CRM.Domain.Entities.Marketing;
using CRM.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRM.Application.Interfaces
{
    public interface ICRMDbContext : IDisposable
    {

        //LeadManagement
        DbSet<ActivityFeed> ActivityFeeds { get; set; }
        DbSet<Call> Calls { get; set; }
        //DbSet<Company> Companies { get; set; }
        //DbSet<CompanyCall> CompaniesCalls { get; set; }
        //DbSet<CompanyContact> CompaniesContacts { get; set; }
        //DbSet<CompanyIndustry> CompanyIndustries { get; set; }
        //DbSet<CompanyOpportunity> CompaniesOpportunities { get; set; }
        //DbSet<Contact> Contacts { get; set; }
        //DbSet<ContactCall> ContactsCalls { get; set; }
        //DbSet<ContactOpportunity> ContactsOpportunities { get; set; }
        //DbSet<ListOfCompany> ListOfCompanies { get; set; }
        //DbSet<ListOfContact> ListOfContacts { get; set; }
        //DbSet<ListOfOpportunity> ListOfOpportunities { get; set; }
        //DbSet<ObjectList> ObjectList { get; set; }
        //DbSet<OpportunityCall> OpportunitiesCalls { get; set; }



        //Marketing
        //DbSet<Campaign> Campaigns { get; set; }
        //DbSet<CampaignMember> CampaignMembers { get; set; }

        ////Sales
        //DbSet<Opportunity> Opportunities { get; set; }
        //DbSet<Product> Products { get; set; }

        //Support


        IDbContextTransaction DatabaseBeginTransaction();
        Task SaveChangesAsync();
        DbSet<TEntity> set<TEntity>() where TEntity : class;

    }
}
