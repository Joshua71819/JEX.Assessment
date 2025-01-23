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
    public ActionResult<JobPostingDetail> GetJobPosting(int id)
    {
        var jobPostingDetail = _jobPostingService.GetJobPostingDetail(id);
        return Ok(jobPostingDetail);
    }

    [HttpPost]
    public ActionResult<int> CreateJobPosting([FromBody] JobPostingInput jobPostingInput)
    {
        var jobPostingId = _jobPostingService.AddJobPosting(jobPostingInput);
        return CreatedAtAction(nameof(CreateJobPosting), jobPostingId);
    }

    [HttpPut("{id}")]
    public ActionResult<int> UpdateJobPosting(int id, [FromBody] JobPostingInput jobPostingInput)
    {
        _jobPostingService.UpdateJobPosting(id, jobPostingInput);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteJobPosting(int id)
    {
        _jobPostingService.DeleteJobPosting(id);
        return Ok();
    }

    [HttpPatch("{id}/isActive")]
    public ActionResult UpdateJobPostingStatus(int id, [FromBody] bool isActive)
    {
        _jobPostingService.SetStatus(id, isActive);
        return Ok();
    }
}

