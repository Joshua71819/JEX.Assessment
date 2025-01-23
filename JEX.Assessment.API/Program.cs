using JEX.Assessment.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyJobsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(CompanyJobsDbContext))));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
