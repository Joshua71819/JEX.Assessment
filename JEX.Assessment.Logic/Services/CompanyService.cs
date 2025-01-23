using JEX.Assessment.Data;
using JEX.Assessment.Data.Entities;
using JEX.Assessment.Logic.Models;

namespace JEX.Assessment.Logic.Services;

public class CompanyService : ICompanyService
{
    private readonly CompanyJobsDbContext _companyJobsDbContext;

    public CompanyService(CompanyJobsDbContext companyJobsDbContext)
    {
        _companyJobsDbContext = companyJobsDbContext;
    }

    public List<CompanyOverview> GetCompanies() =>
       _companyJobsDbContext.Companies.Select(c => new CompanyOverview
       {
           Id = c.Id,
           Name = c.Name
       }).ToList();

    public List<CompanyOverview> GetCompaniesWithOpenPostings() =>
       _companyJobsDbContext.Companies
        .Where(c => c.JobPostings.Any(jp => jp.IsActive))
        .Select(c => new CompanyOverview
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();

    public CompanyDetail GetCompanyDetail(int companyId) => _companyJobsDbContext.Companies
        .Where(c => c.Id == companyId)
        .Select(c => new CompanyDetail
        {
            Id = c.Id,
            Name = c.Name,
            Street = c.Street,
            StreetNumber = c.StreetNumber,
            StreetNumberSuffix = c.StreetNumberSuffix,
            City = c.City,
        }).First();

    public int AddCompany(CompanyInput companyInput)
    {
        if (_companyJobsDbContext.Companies.Any(c => c.Name == companyInput.Name))
        {
            throw new InvalidOperationException("Company with this name already exists");
        }

        var company = new Company
        {
            Name = companyInput.Name,
            Street = companyInput.Street,
            StreetNumber = companyInput.StreetNumber,
            StreetNumberSuffix = companyInput.StreetNumberSuffix,
            City = companyInput.City
        };
        
        _companyJobsDbContext.Companies.Add(company);
        _companyJobsDbContext.SaveChanges();

        return company.Id;
    }

    public void UpdateCompany(int companyId, CompanyInput companyInput)
    {
        var company = _companyJobsDbContext.Companies.Find(companyId);
        company.Name = companyInput.Name;
        company.Street = companyInput.Street;
        company.StreetNumber = companyInput.StreetNumber;
        company.StreetNumberSuffix = companyInput.StreetNumberSuffix;
        company.City = companyInput.City;
        _companyJobsDbContext.SaveChanges();
    }
}
