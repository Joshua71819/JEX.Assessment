using JEX.Assessment.Logic.Models;
using JEX.Assessment.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JEX.Assessment.API.Controllers;

[ApiController]
[Route("[controller]")]
public class JobPostingsController : ControllerBase
{
    private readonly IJobPostingService _jobPostingService;
    public JobPostingsController(IJobPostingService jobPostingService)
    {
        _jobPostingService = jobPostingService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JobPostingDetail>> GetJobPosting(int id)
    {
        var jobPostingDetail = await _jobPostingService.GetJobPostingDetail(id);
        return Ok(jobPostingDetail);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateJobPosting([FromBody] JobPostingInput jobPostingInput)
    {
        var jobPostingId = await _jobPostingService.AddJobPosting(jobPostingInput);
        return CreatedAtAction(nameof(CreateJobPosting), jobPostingId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateJobPosting(int id, [FromBody] JobPostingInput jobPostingInput)
    {
        await _jobPostingService.UpdateJobPosting(id, jobPostingInput);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteJobPosting(int id)
    {
        await _jobPostingService.DeleteJobPosting(id);
        return Ok();
    }

    [HttpPatch("{id}/isActive")]
    public async Task<ActionResult> UpdateJobPostingStatus(int id, [FromBody] bool isActive)
    {
        await _jobPostingService.SetStatus(id, isActive);
        return Ok();
    }
}

