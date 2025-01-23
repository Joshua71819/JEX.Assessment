using JEX.Assessment.Logic.Models;

namespace JEX.Assessment.Logic.Services;

public interface ICompanyService
{
    public CompanyDetail GetCompanyDetail(int companyId);
    public List<CompanyOverview> GetCompanies();
    public List<CompanyOverview> GetCompaniesWithOpenPostings();
}