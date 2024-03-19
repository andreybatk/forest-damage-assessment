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
    // dotnet ef migrations add InitIdentity --project PhoneBook.DB --startup-project PhoneBook
    // dotnet ef database update --project PhoneBook.DB --startup-project PhoneBook

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Assortment> Assortments { get; set; }
        public DbSet<AssortmentExtra> AssortmentsExtra { get; set; }
        public DbSet<AssortmentLinden> AssortmentsLinden { get; set; }
        public DbSet<BreedDiameterModel> BreedDiameterModels { get; set; }
        public DbSet<RankHeights> RankHeights { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<STD> STDs { get; set; }
        public DbSet<TaxPrice> TaxPrices { get; set; }
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
