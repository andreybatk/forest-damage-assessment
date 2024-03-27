using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace ForestDamageAssessment.DB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            #pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ForestDamageAssessment.DB.Models.Assortment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AllBusiness")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average1Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average1_1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average1_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average1_3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2_1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2_3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirewoodFuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("H")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Large1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Large2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Large3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LargeTotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RankH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Small1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Small2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Small3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallTotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnologicalRawMaterials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThicknessLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VInBark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Waste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Assortment");
                });

            modelBuilder.Entity("ForestDamageAssessment.DB.Models.AssortmentExtra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Average1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommodityRidge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirewoodFuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirewoodFuelFirewood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("H")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Large")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlywoodLog")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Podtovarnik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RankH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sawlog")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Small")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stroyles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnologicalRawMaterials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnologicalRawMaterialsFirewood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThicknessLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VInBark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Waste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WasteFirewood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AssortmentExtra");
                });

            modelBuilder.Entity("ForestDamageAssessment.DB.Models.AssortmentLinden", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AllBusiness")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average1Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average1_1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average1_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average1_3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2_1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Average2_3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirewoodFuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("H")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Large1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Large2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Large3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LargeTotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RankH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Small1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Small2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Small3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallTotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnologicalRawMaterials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThicknessLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VInBark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Waste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AssortmentLinden");
                });

            modelBuilder.Entity("ForestDamageAssessment.DB.Models.BreedDiameterModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("BreedDiameterModel");
                });

            modelBuilder.Entity("ForestDamageAssessment.DB.Models.RankHeights", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RankH")
                        .HasColumnType("int");

                    b.Property<string>("ThicknessLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("RanksHeights");
                });

            modelBuilder.Entity("ForestDamageAssessment.DB.Models.Regions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("ForestDamageAssessment.DB.Models.STD", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ThicknessLevel")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("STD");
                });

            modelBuilder.Entity("ForestDamageAssessment.DB.Models.TaxPrice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Firewood")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceAverage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceLarge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceSmall")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RankTax")
                        .HasColumnType("int");

                    b.Property<string>("SubjectRF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxPriceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxPriceDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransportationDistance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TaxPrice");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
            #pragma warning restore 612, 618
        }
    }
}