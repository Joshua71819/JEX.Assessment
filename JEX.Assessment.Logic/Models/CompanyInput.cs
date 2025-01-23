using System.ComponentModel.DataAnnotations;

namespace JEX.Assessment.Logic.Models;

public class CompanyInput
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Street { get; set; }
    
    [Required]
    public int StreetNumber { get; set; }
    
    [Required]
    public string? StreetNumberSuffix { get; set; }
    
    public string City { get; set; }
}
