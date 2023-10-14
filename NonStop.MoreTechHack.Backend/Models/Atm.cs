namespace NonStop.MoreTechHack.Backend.Models;

public class Atm
{
    public string? Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool AllDay { get; set; }
    public Services? Services { get; set; }
}
