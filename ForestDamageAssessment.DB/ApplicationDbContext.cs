using ForestDamageAssessment.DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForestDamageAssessment.DB
{
    // dotnet ef migrations add InitFDATables --project ForestDamageAssessment.DB --startup-project ForestDamageAssessment
    // dotnet ef database update --project ForestDamageAssessment.DB --startup-project ForestDamageAssessment
    // dotnet ef migrations remove --project ForestDamageAssessment.DB --startup-project ForestDamageAssessment
    // dotnet ef database update 20240313124758_InitIdentity --project ForestDamageAssessment.DB --startup-project ForestDamageAssessment

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Assortment> Assortments { get; set; }
        public DbSet<AssortmentExtra> AssortmentsExtra { get; set; }
        public DbSet<AssortmentLinden> AssortmentsLinden { get; set; }
        public DbSet<BreedDiameterModel> BreedDiameterModels { get; set; }
        public DbSet<STD> STDs { get; set; }
        public DbSet<TaxPrice> TaxPrices { get; set; }
        public DbSet<TaxPriceForestResource> TaxPricesForestResource { get; set; }
        public DbSet<TaxPriceResin> TaxPricesResin { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}