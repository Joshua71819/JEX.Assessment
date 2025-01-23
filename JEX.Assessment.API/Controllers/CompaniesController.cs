using JEX.Assessment.Logic.Models;
using JEX.Assessment.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JEX.Assessment.API.Controllers;

[ApiController]
[Route("[controller]")]

public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;
    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public List<CompanyOverview> GetCompanies() => _companyService.GetCompanies();

    [HttpGet("/hiring")]
    public List<CompanyOverview> GetCompaniesWithOpenJobPostings() => _companyService.GetCompaniesWithOpenPostings();

    [HttpGet("{id}")]
    public CompanyDetail GetCompany(int id) => _companyService.GetCompanyDetail(id);

    [HttpPost]
    public void AddCompany([FromBody] CompanyInput company)
    {
        // Add company to database
    }
}
