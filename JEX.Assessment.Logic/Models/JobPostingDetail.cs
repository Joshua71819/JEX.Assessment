namespace JEX.Assessment.Logic.Models;

public class JobPostingDetail
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? MinMonthlySalary { get; set; }
    public int? MaxMonthlySalary { get; set; }
    public int? MinHoursPerWeek { get; set; }
    public int? MaxHoursPerWeek { get; set; }
}
