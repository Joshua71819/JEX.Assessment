using JEX.Assessment.Logic.Models;

namespace JEX.Assessment.Logic.Services;

public interface IJobPostingService
{
    public int AddJobPosting (JobPostingInput jobPostingInput);
    public JobPostingDetail GetJobPostingDetail(int id);
    public List<JobPostingSummary> GetJobPostingsForCompany(int companyId);

    void UpdateJobPosting(int id, JobPostingInput company);
    void DeleteJobPosting(int id);
}