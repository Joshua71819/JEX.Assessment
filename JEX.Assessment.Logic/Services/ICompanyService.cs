using JEX.Assessment.Logic.Models;

namespace JEX.Assessment.Logic.Services;

public interface ICompanyService
{
    public int AddCompany(CompanyInput companyInput);
    public CompanyDetail GetCompanyDetail(int id, bool includeInactiveJobPostings);
    public List<CompanySummary> GetCompanies(bool retrieveOnlyHiringCompanies);
    public void UpdateCompany(int id, CompanyInput companyInput);
    public void DeleteCompany(int id);
}