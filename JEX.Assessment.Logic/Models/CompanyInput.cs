using System.ComponentModel.DataAnnotations;

namespace JEX.Assessment.Logic.Models;

public class CompanyInput
{
    [Required]
    [MaxLength(60)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(60)]
    public string Street { get; set; }
    
    [Required]
    public int StreetNumber { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string? StreetNumberSuffix { get; set; }

    [Required]
    [MaxLength(7)]
    public string PostalCode { get; set; }
    [MaxLength(60)]
    public string City { get; set; }

    [MaxLength(60)]
    public string? Website { get; set; }

    [MaxLength(20)]
    public string? Email { get; set; }

    [MaxLength(15)]
    public string? PhoneNumber { get; set; }
}
