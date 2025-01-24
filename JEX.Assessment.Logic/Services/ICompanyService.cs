using JEX.Assessment.Logic.Models;

namespace JEX.Assessment.Logic.Services;

public interface ICompanyService
{
    public Task<int> AddCompany(CompanyInput companyInput);
    public Task<CompanyDetail> GetCompanyDetail(int id, bool includeInactiveJobPostings);
    public Task<List<CompanySummary>> GetCompanies(bool retrieveOnlyHiringCompanies);
    public Task UpdateCompany(int id, CompanyInput companyInput);
    public Task DeleteCompany(int id);
}
