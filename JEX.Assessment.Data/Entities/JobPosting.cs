using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JEX.Assessment.Data.Entities;

public class JobPosting
{
    public int Id { get; set; }
    public required int CompanyId { get; set; }

    public Company Company { get; set; }

    [MaxLength(60)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public int? MinMonthlySalary { get; set; }
    public int? MaxMonthlySalary { get; set; }

    [Column(TypeName = "tinyint")]
    public int? MinHoursPerWeek { get; set; }

    [Column(TypeName = "tinyint")]    
    public int? MaxHoursPerWeek { get; set; }
    
    public bool IsActive { get; set; }
}
