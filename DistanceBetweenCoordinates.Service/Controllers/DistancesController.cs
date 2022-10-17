using DistanceBetweenCoordinates.DTOs;
using DistanceBetweenCoordinates.Models;
using DistanceBetweenCoordinates.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DistanceBetweenCoordinates.Controllers;

[ApiController]
[Route("[controller]")]
public class DistancesController : ControllerBase
{
    private readonly DistanceService distanceService;
    private readonly ILogger<DistancesController> _logger;

    public DistancesController(ILogger<DistancesController> logger, DistanceService _distanceService)
    {
        _logger = logger;
        distanceService = _distanceService;
    }

    [HttpPost(Name = "CalculateDistance")]
    public async Task<DistanceDTO> CalculateDistance([FromBody] CoordinatesDTO coordinates)
    {
        return await this.distanceService.CalculateDistanceBetweenTwoCoordinates(coordinates.FirstCoordinate, coordinates.SecondCoordinate);
    }
}
