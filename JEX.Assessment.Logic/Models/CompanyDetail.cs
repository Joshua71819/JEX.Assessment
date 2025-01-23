namespace JEX.Assessment.Logic.Models;

public class CompanyDetail
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public int StreetNumber { get; set; }
    public string? StreetNumberSuffix { get; set; }
    public string City { get; set; }
}
