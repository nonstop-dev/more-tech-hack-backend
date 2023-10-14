using NonStop.MoreTechHack.Backend.Dtos;
using NonStop.MoreTechHack.Backend.Extensions;
using NonStop.MoreTechHack.Backend.Helpers;
using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Data;

public class PointsProvider : IPointsProvider
{
    private List<PointDto>? _pointDtos;

    public IEnumerable<PointDto>? GetPoints()
    {
        if (_pointDtos != null)
            return _pointDtos;

        var points = JsonHelper.LoadJson<IEnumerable<Point>?>("Data/offices.json");
        _pointDtos = points?.Select(point => point.ToPointDto()).ToList();
        return _pointDtos;
    }

    public PointDto? GetPoint(Guid id) =>
        _pointDtos?.FirstOrDefault(point => point.Id == id);
}
