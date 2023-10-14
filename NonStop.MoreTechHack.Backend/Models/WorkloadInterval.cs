namespace NonStop.MoreTechHack.Backend.Models;

public record WorkloadInterval
{
    public string From { get; init; } = null!;
    public string To { get; init; } = null!;
    public int Time { get; init; }
}