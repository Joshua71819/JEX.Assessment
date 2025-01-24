using JEX.Assessment.Data;
using JEX.Assessment.Data.Entities;
using JEX.Assessment.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace JEX.Assessment.Logic.Services;

public class CompanyService : ICompanyService
{
    private readonly CompanyJobsDbContext _companyJobsDbContext;

    public CompanyService(CompanyJobsDbContext companyJobsDbContext)
    {
        _companyJobsDbContext = companyJobsDbContext;
    }

    public async Task<List<CompanySummary>> GetCompanies(bool retrieveOnlyHiringCompanies)
    {
        var companyQuery = retrieveOnlyHiringCompanies ?
            _companyJobsDbContext.Companies.Where(c => c.JobPostings.Any(jp => jp.IsActive)) :
            _companyJobsDbContext.Companies.AsQueryable();

        return await companyQuery.Select(c => new CompanySummary(c.Id, c.Name)).ToListAsync();
    }

    public async Task<CompanyDetail> GetCompanyDetail(int id, bool includeInactiveJobPostings) =>
        await _companyJobsDbContext.Companies
            .Where(c => c.Id == id)
            .Select(c => new CompanyDetail
            {
                Id = c.Id,
                Name = c.Name,
                Address = $"{c.Street} {c.StreetNumber}{c.StreetNumberSuffix}",
                PostalCode = c.PostalCode,
                Website = c.Website,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                City = c.City,
                JobPostings = c.JobPostings.Where(jp => includeInactiveJobPostings || jp.IsActive).Select(jp => new JobPostingSummary(jp.Id, jp.Title, jp.IsActive)).ToArray()
            })
        .FirstOrDefaultAsync() ?? throw new InvalidOperationException($"Company with Id {id} does not exists");

    public async Task<int> AddCompany(CompanyInput companyInput)
    {
        if (await _companyJobsDbContext.Companies.AnyAsync(c => c.Name == companyInput.Name))
        {
            throw new InvalidOperationException("Company with this name already exists");
        }

        var company = new Company
        {
            Name = companyInput.Name,
            Street = companyInput.Street,
            StreetNumber = companyInput.StreetNumber,
            StreetNumberSuffix = companyInput.StreetNumberSuffix,
            PostalCode = companyInput.PostalCode,
            City = companyInput.City,
            Website = companyInput.Website,
            Email = companyInput.Email,
            PhoneNumber = companyInput.PhoneNumber
        };

        _companyJobsDbContext.Companies.Add(company);
        await _companyJobsDbContext.SaveChangesAsync();

        return company.Id;
    }

    public async Task UpdateCompany(int id, CompanyInput companyInput)
    {
        var company = await _companyJobsDbContext.Companies.FindAsync(id) ??
            throw new InvalidOperationException($"Company with Id {id} does not exists");

        company.Name = companyInput.Name;
        company.Street = companyInput.Street;
        company.StreetNumber = companyInput.StreetNumber;
        company.StreetNumberSuffix = companyInput.StreetNumberSuffix;
        company.City = companyInput.City;
        company.Website = companyInput.Website;
        company.Email = companyInput.Email;
        company.PhoneNumber = companyInput.PhoneNumber;

        await _companyJobsDbContext.SaveChangesAsync();
    }

    public async Task DeleteCompany(int id) =>
        await _companyJobsDbContext.Companies
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
}
