using Microsoft.AspNetCore.Mvc;
using NonStop.MoreTechHack.Backend.Models;

namespace NonStop.MoreTechHack.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PointsController : ControllerBase
{
    private readonly ILogger<PointsController> _logger;

    public PointsController(ILogger<PointsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Enumerable.Empty<Point>());
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] Guid id)
    {
        return Ok(new Point());
    }

    [HttpPost("{id}/book")]
    public IActionResult Post()
    {
        return NoContent();
    }
}