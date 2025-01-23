using JEX.Assessment.Logic.Models;

namespace JEX.Assessment.Logic.Services;

public interface ICompanyService
{
    public int AddCompany(CompanyInput companyInput);
    public CompanyDetail GetCompanyDetail(int id, bool includeInactiveJobPostings);
    public List<CompanyOverview> GetCompanies(bool retrieveOnlyHiringCompanies);
    public void UpdateCompany(int companyId, CompanyInput companyInput);
    public void DeleteCompany(int companyId);
}