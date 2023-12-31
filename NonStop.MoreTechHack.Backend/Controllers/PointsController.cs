using Microsoft.AspNetCore.Mvc;
using NonStop.MoreTechHack.Backend.Data;

namespace NonStop.MoreTechHack.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PointsController : ControllerBase
{
    private readonly IPointsProvider _pointsProvider;

    public PointsController(IPointsProvider pointsProvider) =>
        _pointsProvider = pointsProvider;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get()
    {
        var pointDtos = _pointsProvider.GetPoints();
        return Ok(pointDtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get([FromRoute] Guid id)
    {
        var pointDto = _pointsProvider.GetPoint(id);
        if (pointDto == null)
            return NotFound(id);
        return Ok(pointDto);
    }

    [HttpPost("{id}/book")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Post()
    {
        return NoContent();
    }
}