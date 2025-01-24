using JEX.Assessment.Data;
using JEX.Assessment.Data.Entities;
using JEX.Assessment.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace JEX.Assessment.Logic.Services;

public class JobPostingService : IJobPostingService
{
    private readonly CompanyJobsDbContext _companyJobsDbContext;

    public JobPostingService(CompanyJobsDbContext companyJobsDbContext)
    {
        _companyJobsDbContext = companyJobsDbContext;
    }

    public async Task<int> AddJobPosting(JobPostingInput jobPostingInput)
    {
        var jobPosting = new JobPosting
        {
            CompanyId = jobPostingInput.CompanyId,
            Title = jobPostingInput.Title,
            Description = jobPostingInput.Description,
            MinMonthlySalary = jobPostingInput.MinMonthlySalary,
            MaxMonthlySalary = jobPostingInput.MaxMonthlySalary,
            MinHoursPerWeek = jobPostingInput.MinHoursPerWeek,
            MaxHoursPerWeek = jobPostingInput.MaxHoursPerWeek,
            IsActive = true
        };

        _companyJobsDbContext.JobPostings.Add(jobPosting);
        await _companyJobsDbContext.SaveChangesAsync();

        return jobPosting.Id;
    }

    public async Task<JobPostingDetail> GetJobPostingDetail(int id) =>
        await _companyJobsDbContext.JobPostings
            .Where(jp => jp.Id == id)
            .Select(jp => new JobPostingDetail
            {
                Id = jp.Id,
                Title = jp.Title,
                Description = jp.Description,
                CompanyName = jp.Company.Name,
                MinHoursPerWeek = jp.MinHoursPerWeek,
                MaxHoursPerWeek = jp.MaxHoursPerWeek,
                MinMonthlySalary = jp.MinMonthlySalary,
                MaxMonthlySalary = jp.MaxMonthlySalary,
            })
        .FirstOrDefaultAsync() ?? throw new InvalidOperationException($"Posting with Id {id} does not exists");

    public async Task UpdateJobPosting(int id, JobPostingInput jobPostingInput)
    {
        var jobPosting = await _companyJobsDbContext.JobPostings.FindAsync(id) ??
           throw new InvalidOperationException($"Posting with Id {id} does not exists");

        jobPosting.Title = jobPostingInput.Title;
        jobPosting.Description = jobPostingInput.Description;
        jobPosting.MinHoursPerWeek = jobPostingInput.MinHoursPerWeek;
        jobPosting.MaxHoursPerWeek = jobPostingInput.MaxHoursPerWeek;
        jobPosting.MinMonthlySalary = jobPostingInput.MinMonthlySalary;
        jobPosting.MaxMonthlySalary = jobPostingInput.MaxMonthlySalary;

        await _companyJobsDbContext.SaveChangesAsync();
    }

    public async Task SetStatus(int id, bool isActive)
    {
        var jobPosting = await _companyJobsDbContext.JobPostings.FindAsync(id) ??
            throw new InvalidOperationException($"Posting with Id {id} does not exists");

        jobPosting.IsActive = isActive;
        await _companyJobsDbContext.SaveChangesAsync();
    }

    public async Task DeleteJobPosting(int id) =>
        await _companyJobsDbContext.JobPostings
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
}


