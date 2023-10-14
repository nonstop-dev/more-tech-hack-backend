using Microsoft.AspNetCore.Mvc;
using NonStop.MoreTechHack.Backend.Data;

namespace NonStop.MoreTechHack.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PointsController : ControllerBase
{
    private readonly IPointsProvider _pointsProvider;

    public PointsController(IPointsProvider pointsProvider) =>
        _pointsProvider = pointsProvider;

    [HttpGet]
    public IActionResult Get()
    {
        var pointDtos = _pointsProvider.GetPoints();
        return Ok(pointDtos);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] Guid id)
    {
        var pointDto = _pointsProvider.GetPoint(id);
        return Ok(pointDto);
    }

    [HttpPost("{id}/book")]
    public IActionResult Post()
    {
        return NoContent();
    }
}