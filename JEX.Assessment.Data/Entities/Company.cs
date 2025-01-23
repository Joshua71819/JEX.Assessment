using System.ComponentModel.DataAnnotations;

namespace JEX.Assessment.Data.Entities;

public class Company
{
    public int Id { get; set; }

    [MaxLength(60)]
    public required string Name { get; set; }

    [MaxLength(60)]
    public required string Street { get; set; }
    
    public required int StreetNumber { get; set; }

    [MaxLength(10)]
    public string? StreetNumberSuffix { get; set; }

    [MaxLength(60)]
    public required string City { get; set; }

    public Uri? Website { get; set; }

    [EmailAddress]
    public string EmailAddress { get; set; }

    public ICollection<JobPosting> JobPostings { get; set; } 
}
