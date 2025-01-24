using JEX.Assessment.Logic.Models;

namespace JEX.Assessment.Logic.Services;

public interface IJobPostingService
{
    public Task<int> AddJobPosting(JobPostingInput jobPostingInput);
    public Task<JobPostingDetail> GetJobPostingDetail(int id);
    Task UpdateJobPosting(int id, JobPostingInput company);
    Task DeleteJobPosting(int id);
    Task SetStatus(int id, bool isActive);
}
