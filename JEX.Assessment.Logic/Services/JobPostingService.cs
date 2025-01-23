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

    public int AddJobPosting(JobPostingInput jobPostingInput)
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
        };

        _companyJobsDbContext.JobPostings.Add(jobPosting);
        _companyJobsDbContext.SaveChanges();

        return jobPosting.Id;
    }

    public JobPostingDetail GetJobPostingDetail(int id) =>
        _companyJobsDbContext.JobPostings
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
        .FirstOrDefault() ?? throw new InvalidOperationException($"Posting with Id {id} does not exists");

    public void UpdateJobPosting(int id, JobPostingInput jobPostingInput)
    {
        var jobPosting = _companyJobsDbContext.JobPostings.Find(id) ??
           throw new InvalidOperationException($"Posting with Id {id} does not exists");

        jobPosting.Title = jobPostingInput.Title;
        jobPosting.Description = jobPostingInput.Description;
        jobPosting.MinHoursPerWeek = jobPostingInput.MinHoursPerWeek;
        jobPosting.MaxHoursPerWeek = jobPostingInput.MaxHoursPerWeek;
        jobPosting.MinMonthlySalary = jobPostingInput.MinMonthlySalary;
        jobPosting.MaxMonthlySalary = jobPostingInput.MaxMonthlySalary;

        _companyJobsDbContext.SaveChanges();
    }

    public void SetStatus(int id, bool isActive)
    {
        var jobPosting = _companyJobsDbContext.JobPostings.Find(id) ??
            throw new InvalidOperationException($"Posting with Id {id} does not exists");

        jobPosting.IsActive = isActive;
        _companyJobsDbContext.SaveChanges();

    }

    public void DeleteJobPosting(int id) =>

        _companyJobsDbContext.JobPostings
            .Where(c => c.Id == id)
            .ExecuteDelete();
}


