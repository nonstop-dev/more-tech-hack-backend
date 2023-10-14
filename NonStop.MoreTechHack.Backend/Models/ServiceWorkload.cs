namespace NonStop.MoreTechHack.Backend.Models;

public record ServiceWorkload
{
    public ServiceType ServiceType { get; init; }
    public IEnumerable<Workload> Workloads { get; init; } = null!;
}
