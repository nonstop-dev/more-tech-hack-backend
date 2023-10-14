using NonStop.MoreTechHack.Backend.Dtos;
using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Extensions;

public static class AtmExtensions
{
    public static AtmDto ToAtmDto(this Atm atm) => new()
    {
        Id = Guid.NewGuid(),
        Address = atm.Address,
        AllDay = atm.AllDay,
        Latitude = atm.Latitude,
        Longitude = atm.Longitude,
        Services = atm.Services
    };
}
