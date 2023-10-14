using NonStop.MoreTechHack.Backend.Dtos;

namespace NonStop.MoreTechHack.Backend.Data;

public interface IPointsProvider
{
    Task<IEnumerable<PointDto>?> GetPoints(double? latitude = default, double? longitude = default);
    PointDto? GetPoint(Guid id);
}
