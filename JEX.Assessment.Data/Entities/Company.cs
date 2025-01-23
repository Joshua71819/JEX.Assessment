using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JEX.Assessment.Data.Entities;

[Index(nameof(Name), IsUnique = true)]
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

    [MaxLength(7)]
    public required string PostalCode { get; set; }

    [MaxLength(60)]
    public required string City { get; set; }

    [MaxLength(60)]
    public string? Website { get; set; }

    [MaxLength(30)]
    public string? Email { get; set; }

    [MaxLength(15)]
    public string? PhoneNumber { get; set; }

    public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
}
