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

    public List<CompanyOverview> GetCompanies(bool retrieveOnlyHiringCompanies) {
        var companyQuery = retrieveOnlyHiringCompanies ? 
            _companyJobsDbContext.Companies.Where(c => c.JobPostings.Any(jp => jp.IsActive)) : 
            _companyJobsDbContext.Companies.AsQueryable();      
       
        return companyQuery.Select(c => new CompanyOverview
         {
            Id = c.Id,
            Name = c.Name,
        }).ToList();
    }

    public CompanyDetail GetCompanyDetail(int id, bool includeInactiveJobPostings) =>
        _companyJobsDbContext.Companies
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
        .FirstOrDefault() ?? throw new InvalidOperationException($"Company with Id {id} does not exists");

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
            PostalCode = companyInput.PostalCode,
            City = companyInput.City,
            Website = companyInput.Website,
            Email = companyInput.Email,
            PhoneNumber = companyInput.PhoneNumber
        };
        
        _companyJobsDbContext.Companies.Add(company);
        _companyJobsDbContext.SaveChanges();

        return company.Id;
    }

    public void UpdateCompany(int id, CompanyInput companyInput)
    {
        var company = _companyJobsDbContext.Companies.Find(id) ??
            throw new InvalidOperationException($"Company with Id {id} does not exists");

        company.Name = companyInput.Name;
        company.Street = companyInput.Street;
        company.StreetNumber = companyInput.StreetNumber;
        company.StreetNumberSuffix = companyInput.StreetNumberSuffix;
        company.City = companyInput.City;
        company.Website = companyInput.Website;
        company.Email = companyInput.Email;
        company.PhoneNumber = companyInput.PhoneNumber;

        _companyJobsDbContext.SaveChanges();
    }

    public void DeleteCompany(int id) =>
        _companyJobsDbContext.Companies
            .Where(c => c.Id == id)
            .ExecuteDelete();
}
