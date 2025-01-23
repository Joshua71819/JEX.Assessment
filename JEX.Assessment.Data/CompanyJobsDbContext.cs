using JEX.Assessment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JEX.Assessment.Data;

public class CompanyJobsDbContext : DbContext
{
    public CompanyJobsDbContext(DbContextOptions<CompanyJobsDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().AreUnicode(false);
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>().HasData(
            new Company {
                Id = 1,
                Name = "JEX",
                Email = "recruitment@jex.nl",
                Website = "http://www.jex.nl",
                PhoneNumber = "010 300 7869",
                Street = "Nassaukade",
                StreetNumber = 5,
                City = "Rotterdam",
            });

        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 2,
                Name = "KPMG",
                Email = "jobs@kpmg.nl",
                Website = "http://www.kpmg.nl",
                PhoneNumber = "020 431 6232",
                Street = "Hoofdweg",
                StreetNumber = 11,
                City = "Amsterdam",
            });

        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 3,
                Name = "Coolblue",
                Email = "werkenbij@coolblue.nl",
                Website = "http://www.coolblue.nl",
                PhoneNumber = "030 227 5542",
                Street = "Dorpslaan",
                StreetNumber = 23,
                City = "Utrecht",
            });

        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 4,
                Name = "Capgemini",
                Email = "careers@capgemini.nl",
                Website = "http://www.capgemini.nl",
                PhoneNumber = "070 328 2234",
                Street = "Noordplein",
                StreetNumber = 47,
                City = "Den Haag",
            });

        modelBuilder.Entity<JobPosting>().HasData(
             new JobPosting
             {
                 Id = 1,
                 CompanyId = 1,
                 Title = "Backend Developer",
                 Description = "We zijn op zoek naar een ervaren backend developer die ervaring heeft met MassTransit.",
                 IsActive = true
             },
              new JobPosting
              {
                  Id = 2,
                  CompanyId = 1,
                  Title = "Frontend Developer",
                  Description = "We zoeken naar een gedreven frontend developer waar Angular geen geheimen voor heeft!",
                  IsActive = true
              },
             new JobPosting
             {
                 Id = 3,
                 CompanyId = 1,
                 Title = "Software Tester",
                 Description = "Word jij onze nieuwe tester? Soliciteer maar gauw!",
                 IsActive = false
             },
             new JobPosting
             {
                 Id = 4,
                 CompanyId = 2,
                 Title = "QA inspecteur",
                 Description = "Heb jij kwaliteit hoog in het vaandel staan? Dan zoeken we jou!",
                 IsActive = true
             },
             new JobPosting
             {
                 Id = 5,
                 CompanyId = 2,
                 Title = "Database beheerder",
                 Description = "We zoeken naar iemand met ruime ervaring als DB-beheerder",
                 IsActive = false
             },
             new JobPosting
             {
                 Id = 6,
                 CompanyId = 3,
                 Title = "Magazijnmedewerker",
                 Description = "Kom werken in ons magazijn!",
                 IsActive = false
             },
             new JobPosting
             {
                 Id = 7,
                 CompanyId = 3,
                 Title = "Audiospecialist",
                 Description = "Adviseer onze klanten speakers en hifi",
                 IsActive = false
             }
        );
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<JobPosting> JobPostings { get; set; }
}
