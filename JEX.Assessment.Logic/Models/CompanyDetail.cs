﻿namespace JEX.Assessment.Logic.Models;

public class CompanyDetail
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public JobPostingSummary[] JobPostings { get; set; }
}
