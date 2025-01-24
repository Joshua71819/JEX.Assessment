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
    public async Task<ActionResult<List<CompanySummary>>> GetCompanies([FromQuery] bool onlyHiringCompanies) => await _companyService.GetCompanies(onlyHiringCompanies);

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDetail>> GetCompany(int id, [FromQuery] bool includeInactiveJobPostings) => await _companyService.GetCompanyDetail(id, includeInactiveJobPostings);

    [HttpPost]
    public async Task<ActionResult<int>> AddCompany([FromBody] CompanyInput company)
    {
        var companyId = await _companyService.AddCompany(company);
        return CreatedAtAction(nameof(AddCompany), companyId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateCompany(int id, [FromBody] CompanyInput company)
    {
        await _companyService.UpdateCompany(id, company);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteCompany(int id)
    {
        _companyService.DeleteCompany(id);
        return Ok();
    }
}
