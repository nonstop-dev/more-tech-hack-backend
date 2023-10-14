using Microsoft.AspNetCore.Mvc;
using NonStop.MoreTechHack.Backend.Data;

namespace NonStop.MoreTechHack.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AtmsController : ControllerBase
{
    private readonly IAtmsProvider _atmsProvider;

    public AtmsController(IAtmsProvider atmsProvider) =>
        _atmsProvider = atmsProvider;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        var pointDtos = _atmsProvider.GetAtms();
        return Ok(pointDtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get([FromRoute] Guid id)
    {
        var atmDto = _atmsProvider.GetAtm(id);
        if (atmDto == null)
            return NotFound(id);
        return Ok(atmDto);
    }
}
