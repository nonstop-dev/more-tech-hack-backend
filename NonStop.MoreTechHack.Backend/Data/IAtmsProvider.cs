using NonStop.MoreTechHack.Backend.Dtos;

namespace NonStop.MoreTechHack.Backend.Data;

public interface IAtmsProvider
{
    IEnumerable<AtmDto>? GetAtms();
    AtmDto? GetAtm(Guid id);
}
