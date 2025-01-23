using System.ComponentModel.DataAnnotations;

namespace JEX.Assessment.Data.Entities;

public class JobPosting
{
    public required int Id { get; set; }

    [MaxLength(60)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }
    
    public bool IsActive { get; set; }
    public Company Company { get; set; }
}
