namespace NonStop.MoreTechHack.Backend.Models;

public record Workload
{
    public int Week { get; init; }
    public string Day { get; init; } = null!;
    public IEnumerable<WorkloadInterval> Intervals { get; init; } = null!;
}
