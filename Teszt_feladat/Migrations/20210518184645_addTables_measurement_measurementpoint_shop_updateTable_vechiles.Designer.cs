// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teszt_feladat;

namespace Teszt_feladat.Migrations
{
    [DbContext(typeof(AvanderDbContext))]
    [Migration("20210518184645_addTables_measurement_measurementpoint_shop_updateTable_vechiles")]
    partial class addTables_measurement_measurementpoint_shop_updateTable_vechiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teszt_feladat.Entities.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Flush")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal?>("Gap")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("MeasurementPointId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MyProperty")
                        .HasColumnType("datetime");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<int>("VechicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementPointId");

                    b.HasIndex("ShopId");

                    b.HasIndex("VechicleId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Teszt_feladat.Entities.MeasurementPoint", b =>
                {
                    b.Property<int>("MeasurementPointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MeasurementPointId");

                    b.ToTable("MeasurementPoints");
                });

            modelBuilder.Entity("Teszt_feladat.Entities.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ShopId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Teszt_feladat.Entities.Vechicle", b =>
                {
                    b.Property<int>("VechicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JSN")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("VechicleModel")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VechicleId");

                    b.ToTable("Vechicles");
                });

            modelBuilder.Entity("Teszt_feladat.Entities.Measurement", b =>
                {
                    b.HasOne("Teszt_feladat.Entities.MeasurementPoint", "MeasurementPoint")
                        .WithMany("MyProperty")
                        .HasForeignKey("MeasurementPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teszt_feladat.Entities.Shop", "Shop")
                        .WithMany("MyProperty")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teszt_feladat.Entities.Vechicle", "Vechicle")
                        .WithMany("MyProperty")
                        .HasForeignKey("VechicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasurementPoint");

                    b.Navigation("Shop");

                    b.Navigation("Vechicle");
                });

            modelBuilder.Entity("Teszt_feladat.Entities.MeasurementPoint", b =>
                {
                    b.Navigation("MyProperty");
                });

            modelBuilder.Entity("Teszt_feladat.Entities.Shop", b =>
                {
                    b.Navigation("MyProperty");
                });

            modelBuilder.Entity("Teszt_feladat.Entities.Vechicle", b =>
                {
                    b.Navigation("MyProperty");
                });
#pragma warning restore 612, 618
        }
    }
}
