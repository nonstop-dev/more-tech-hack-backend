using NonStop.MoreTechHack.Backend.Dtos;
using NonStop.MoreTechHack.Backend.Extensions;
using NonStop.MoreTechHack.Backend.Helpers;
using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Data;

public class PointsProvider : IPointsProvider
{
    private readonly IWorkloadProvider _workloadProvider;
    private List<PointDto>? _pointDtos;

    public PointsProvider(IWorkloadProvider workloadProvider)
    {
        _workloadProvider = workloadProvider;
    }

    public async Task<IEnumerable<PointDto>?> GetPoints(double? latitude, double? longitude)
    {
        if (_pointDtos == null)
        {
            var points = JsonHelper.LoadJson<IEnumerable<Point>?>("Data/offices.json");
            _pointDtos = points?.Select(point => point.ToPointDto()).ToList();
        }

        //TODO: remove it for real location
        latitude ??= 56.183239;
        longitude ??= 36.984314;
        const double speed = 60;

        var now = DateTimeOffset.UtcNow;
        foreach (var pointDto in _pointDtos)
        {
            var distance = GetDistanceInKm(
                pointDto.Latitude,
                pointDto.Longitude,
                latitude.Value,
                longitude.Value);

            var arrivalTime = now.AddHours(distance / speed);
            var workload = await _workloadProvider.GetWorkloadAsync(
                pointDto.Id,
                arrivalTime,
                ServiceType.Common,
                CancellationToken.None);

            pointDto.ScheduledTime = workload != null
                ? arrivalTime.AddMinutes(workload.Value)
                : arrivalTime;
        }

        return _pointDtos;
    }

    public PointDto? GetPoint(Guid id) =>
        _pointDtos?.FirstOrDefault(point => point.Id == id);


    private static double GetDistanceInKm(double latitudeA, double longitudeA, double latitudeB, double longitudeB)
    {
        const double earthRadius = 6371;
        return Math.Acos(Math.Sin(latitudeA) * Math.Sin(latitudeB) +
                         Math.Cos(latitudeA) * Math.Cos(latitudeB) * Math.Cos(longitudeB - longitudeA)) * earthRadius;
    }
}
