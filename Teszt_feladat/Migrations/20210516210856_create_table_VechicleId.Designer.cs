// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teszt_feladat;

namespace Teszt_feladat.Migrations
{
    [DbContext(typeof(AvanderDbContext))]
    [Migration("20210516210856_create_table_VechicleId")]
    partial class create_table_VechicleId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Teszt_feladat.Vechicle", b =>
                {
                    b.Property<int>("VechicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("JSN")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("VechicleModel")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VechicleId");

                    b.ToTable("Vechicles");
                });
#pragma warning restore 612, 618
        }
    }
}
