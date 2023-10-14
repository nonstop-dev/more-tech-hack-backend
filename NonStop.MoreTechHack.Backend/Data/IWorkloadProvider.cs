using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Data;

public interface IWorkloadProvider
{
    Task<IEnumerable<Workload>> GetWorkloadAsync(Guid officeId, int weekNumber, ServiceType serviceType, CancellationToken cancellationToken);

    Task<int?> GetWorkloadAsync(Guid officeId, DateTimeOffset time, ServiceType serviceType, CancellationToken cancellationToken);
}
