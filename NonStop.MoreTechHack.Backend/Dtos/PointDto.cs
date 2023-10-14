using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Dtos;

public class PointDto
{
    public Guid Id { get; set; }
    public string? SalePointName { get; set; }
    public string? Address { get; set; }
    public string? Status { get; set; }
    public IEnumerable<OpenHour>? OpenHours { get; set; }
    public bool? Rko { get; set; }
    public IEnumerable<OpenHour>? OpenHoursIndividual { get; set; }
    public string? OfficeType { get; set; }
    public string? SalePointFormat { get; set; }
    public bool? SuoAvailability { get; set; }
    public bool? HasRamp { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public object? MetroStation { get; set; }
    public int Distance { get; set; }
    public bool? Kep { get; set; }
    public bool MyBranch { get; set; }
}
