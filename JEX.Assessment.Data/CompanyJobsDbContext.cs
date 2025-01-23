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
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<JobPosting> JobPostings { get; set; }
}
