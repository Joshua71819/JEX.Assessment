using System.ComponentModel.DataAnnotations;

namespace JEX.Assessment.Logic.Models;

public class JobPostingInput
{
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    public int? MinMonthlySalary { get; set; }

    public int? MaxMonthlySalary { get; set; }

    public int? MinHoursPerWeek { get; set; }

    public int? MaxHoursPerWeek { get; set; }
}
