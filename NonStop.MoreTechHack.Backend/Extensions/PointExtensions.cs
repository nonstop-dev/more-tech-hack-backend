using NonStop.MoreTechHack.Backend.Dtos;
using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Extensions;

public static class PointExtensions
{
    public static PointDto ToPointDto(this Point point) => new()
    {
        Id = Guid.NewGuid(),
        Address = point.Address,
        Latitude = point.Latitude,
        Longitude = point.Longitude,
        Distance = point.Distance,
        Kep = point.Kep,
        MetroStation = point.MetroStation,
        MyBranch = point.MyBranch,
        OfficeType = point.OfficeType,
        OpenHours = point.OpenHours,
        OpenHoursIndividual = point.OpenHoursIndividual,
        SalePointFormat = point.SalePointFormat,
        SalePointName = point.SalePointName,
        Status = point.Status,
        SuoAvailability = GetBoolValue(point.SuoAvailability),
        HasRamp = GetBoolValue(point.HasRamp),
        Rko = GetRkoValue(point.Rko)
    };

    private static bool GetBoolValue(string? rawValue) => rawValue == "Y";
    private static bool GetRkoValue(string? rawValue) => rawValue == "есть РКО";
}
