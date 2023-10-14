using NonStop.MoreTechHack.Backend.Dtos;

namespace NonStop.MoreTechHack.Backend.Data;

public interface IPointsProvider
{
    IEnumerable<PointDto>? GetPoints();
    PointDto? GetPoint(Guid id);
}
