
using Common.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace CRM.Domain.Entities.Sales
{
    public class Product : BaseEntity
    {
        [StringLength(225)]
        public string Name { get;  set; } = string.Empty;
        public string Description { get;  set; } = string.Empty;
        public decimal Price { get;  set; } = new decimal();

        public ICollection<Opportunity> Opportunities { get;  set; } = new List<Opportunity>();
    }
}
