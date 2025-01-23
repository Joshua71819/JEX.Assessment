﻿// <auto-generated />
using JEX.Assessment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JEX.Assessment.Data.Migrations
{
    [DbContext(typeof(CompanyJobsDbContext))]
    [Migration("20250123113655_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JEX.Assessment.Data.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<string>("StreetNumberSuffix")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Website")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Rotterdam",
                            Email = "recruitment@jex.nl",
                            Name = "JEX",
                            PhoneNumber = "010 300 7869",
                            Street = "Nassaukade",
                            StreetNumber = 5,
                            Website = "http://www.jex.nl"
                        },
                        new
                        {
                            Id = 2,
                            City = "Amsterdam",
                            Email = "jobs@kpmg.nl",
                            Name = "KPMG",
                            PhoneNumber = "020 431 6232",
                            Street = "Hoofdweg",
                            StreetNumber = 11,
                            Website = "http://www.kpmg.nl"
                        },
                        new
                        {
                            Id = 3,
                            City = "Utrecht",
                            Email = "werkenbij@coolblue.nl",
                            Name = "Coolblue",
                            PhoneNumber = "030 227 5542",
                            Street = "Dorpslaan",
                            StreetNumber = 23,
                            Website = "http://www.coolblue.nl"
                        },
                        new
                        {
                            Id = 4,
                            City = "Den Haag",
                            Email = "careers@capgemini.nl",
                            Name = "Capgemini",
                            PhoneNumber = "070 328 2234",
                            Street = "Noordplein",
                            StreetNumber = 47,
                            Website = "http://www.capgemini.nl"
                        });
                });

            modelBuilder.Entity("JEX.Assessment.Data.Entities.JobPosting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte?>("MaxHoursPerWeek")
                        .HasColumnType("tinyint");

                    b.Property<int?>("MaxMonthlySalary")
                        .HasColumnType("int");

                    b.Property<byte?>("MinHoursPerWeek")
                        .HasColumnType("tinyint");

                    b.Property<int?>("MinMonthlySalary")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobPostings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Description = "We zijn op zoek naar een ervaren backend developer die ervaring heeft met MassTransit.",
                            IsActive = true,
                            Title = "Backend Developer"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 1,
                            Description = "We zoeken naar een gedreven frontend developer waar Angular geen geheimen voor heeft!",
                            IsActive = true,
                            Title = "Frontend Developer"
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 1,
                            Description = "Word jij onze nieuwe tester? Soliciteer maar gauw!",
                            IsActive = false,
                            Title = "Software Tester"
                        },
                        new
                        {
                            Id = 4,
                            CompanyId = 2,
                            Description = "Heb jij kwaliteit hoog in het vaandel staan? Dan zoeken we jou!",
                            IsActive = true,
                            Title = "QA inspecteur"
                        },
                        new
                        {
                            Id = 5,
                            CompanyId = 2,
                            Description = "We zoeken naar iemand met ruime ervaring als DB-beheerder",
                            IsActive = false,
                            Title = "Database beheerder"
                        },
                        new
                        {
                            Id = 6,
                            CompanyId = 3,
                            Description = "Kom werken in ons magazijn!",
                            IsActive = false,
                            Title = "Magazijnmedewerker"
                        },
                        new
                        {
                            Id = 7,
                            CompanyId = 3,
                            Description = "Adviseer onze klanten speakers en hifi",
                            IsActive = false,
                            Title = "Audiospecialist"
                        });
                });

            modelBuilder.Entity("JEX.Assessment.Data.Entities.JobPosting", b =>
                {
                    b.HasOne("JEX.Assessment.Data.Entities.Company", "Company")
                        .WithMany("JobPostings")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JEX.Assessment.Data.Entities.Company", b =>
                {
                    b.Navigation("JobPostings");
                });
#pragma warning restore 612, 618
        }
    }
}
