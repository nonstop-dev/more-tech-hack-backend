using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Dtos;

public class AtmDto
{
    public Guid Id { get; set; }
    public string? Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool AllDay { get; set; }
    public Services? Services { get; set; }
}