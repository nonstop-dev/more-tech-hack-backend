using NonStop.MoreTechHack.Backend.Dtos;
using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Helpers;

public static class PointsHelper
{

    private static readonly Dictionary<DayOfWeek, string> _days = new()
    {
        { DayOfWeek.Monday, "пн" },
        { DayOfWeek.Tuesday , "вт" },
        { DayOfWeek.Wednesday , "ср" },
        { DayOfWeek.Thursday , "чт" },
        { DayOfWeek.Friday , "пт" },
        { DayOfWeek.Saturday , "сб" },
        { DayOfWeek.Sunday , "вс" }
    };

    public static bool CheckPointAvailability(
        PointDto pointDto,
        DateTime dateTime,
        ClientType clientType)
    {
        var day = _days[dateTime.DayOfWeek];
        var openInterval = clientType == ClientType.Private
                ? pointDto?.OpenHoursIndividual?.FirstOrDefault(oh => oh.Days == day)?.Hours
                : pointDto?.OpenHours?.FirstOrDefault(oh => oh.Days == day)?.Hours;

        if (string.IsNullOrEmpty(openInterval))
            return false;

        var times = openInterval.Split("-");

        if (times.Length != 2)
            return false;

        var openTime = times[0].Split(":");
        var closeTime = times[1].Split(":");
        var openTimeHour = int.Parse(openTime[0]);
        var openTimeMinute = int.Parse(openTime[1]);
        var closeTimeHour = int.Parse(closeTime[0]);
        var closeTimeMinute = int.Parse(closeTime[1]);

        var hour = dateTime.Hour;
        var minute = dateTime.Minute;

        var afterOpen = (hour > openTimeHour) ||
            (hour == openTimeHour && minute > openTimeMinute);
        var beforeClose = (hour < closeTimeHour) ||
            (hour == closeTimeHour && minute < closeTimeMinute);

        return afterOpen && beforeClose;
    }
}
