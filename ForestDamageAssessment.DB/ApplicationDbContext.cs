using ForestDamageAssessment.DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestDamageAssessment.DB
{
    // dotnet ef migrations add InitFDATables --project ForestDamageAssessment.DB --startup-project ForestDamageAssessment
    // dotnet ef database update --project ForestDamageAssessment.DB --startup-project ForestDamageAssessment
    // dotnet ef migrations remove --project ForestDamageAssessment.DB --startup-project ForestDamageAssessment
    // dotnet ef database update 20240313124758_InitIdentity --project ForestDamageAssessment.DB --startup-project ForestDamageAssessment

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Assortment> Assortment { get; set; }
        public DbSet<AssortmentExtra> AssortmentExtra { get; set; }
        public DbSet<AssortmentLinden> AssortmentLinden { get; set; }
        public DbSet<BreedDiameterModel> BreedDiameterModel { get; set; }
        public DbSet<RankHeights> RankHeights { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<STD> STD { get; set; }
        public DbSet<TaxPrice> TaxPrice { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Person>();
        //}
    }
}
