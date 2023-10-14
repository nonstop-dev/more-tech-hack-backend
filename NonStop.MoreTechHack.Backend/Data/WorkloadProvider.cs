using NonStop.MoreTechHack.Backend.Helpers;
using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Data;

public class WorkloadProvider: IWorkloadProvider
{
    public async Task<IEnumerable<Workload>> GetWorkloadAsync(
        Guid officeId, int weekNumber, ServiceType serviceType, CancellationToken cancellationToken)
    {
        var workloads = await GetWorkloadAsync(officeId, serviceType, cancellationToken);
        return workloads.Where(x => x.Week == weekNumber);
    }

    public async Task<int?> GetWorkloadAsync(
        Guid officeId, DateTimeOffset time, ServiceType serviceType, CancellationToken cancellationToken)
    {
        var workloads = await GetWorkloadAsync(officeId, serviceType, cancellationToken);
        var weekNumber = time.Day / 7 + 1;
        var day = GetDayCode(time.DayOfWeek);
        var intervals = workloads
            .FirstOrDefault(x => x.Week == weekNumber && x.Day == day)
            ?.Intervals;

        var interval = intervals?.FirstOrDefault(x =>
        {
            var from = GetTime(x.From);
            var to = GetTime(x.To);

            return (time.Hour > from.Hour || (time.Hour == from.Hour && time.Minute >= from.Minutes))
                   && (time.Hour < to.Hour || (time.Hour == to.Hour && time.Minute <= to.Minutes));
        });

        return interval?.Time;
    }

    private static (int Hour, int Minutes) GetTime(string time)
    {
        var items = time.Split(':').Select(int.Parse).ToList();
        return (items[0], items[1]);
    }

    private static string GetDayCode(DayOfWeek dayOfWeek) =>
        dayOfWeek switch
        {
            DayOfWeek.Monday => "пн",
            DayOfWeek.Tuesday => "вт",
            DayOfWeek.Wednesday => "ср",
            DayOfWeek.Thursday => "чт",
            DayOfWeek.Friday => "пт",
            DayOfWeek.Saturday => "cб",
            DayOfWeek.Sunday => "вс",
            _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null)
        };

    private static Task<IEnumerable<Workload>> GetWorkloadAsync(Guid officeId, ServiceType serviceType, CancellationToken cancellationToken)
    {
        // TODO: It's a stub. The real API call should be make here with filtering by office id and service type.
        var workload = JsonHelper.LoadJson<IEnumerable<ServiceWorkload>?>("Data/workload.json");
        return Task.FromResult(workload.First().Workloads);
    }
}
