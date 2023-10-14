using NonStop.MoreTechHack.Backend.Dtos;
using NonStop.MoreTechHack.Backend.Extensions;
using NonStop.MoreTechHack.Backend.Helpers;
using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Data;

public class AtmsProvider : IAtmsProvider
{
    private List<AtmDto>? _atmDtos;

    public IEnumerable<AtmDto>? GetAtms()
    {
        if (_atmDtos != null)
            return _atmDtos;

        var response = JsonHelper.LoadJson<AtmsResponse?>("Data/atms.json");
        _atmDtos = response?.Atms?.Select(point => point.ToAtmDto()).ToList();
        return _atmDtos;
    }

    public AtmDto? GetAtm(Guid id) =>
        _atmDtos?.FirstOrDefault(atm => atm.Id == id);
}