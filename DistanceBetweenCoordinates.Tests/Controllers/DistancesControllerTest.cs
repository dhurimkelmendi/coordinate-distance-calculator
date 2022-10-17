using System.Net;
using System.Threading.Tasks;
using DistanceBetweenCoordinates.Controllers;
using DistanceBetweenCoordinates.DTOs;
using DistanceBetweenCoordinates.Models;
using DistanceBetweenCoordinates.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
namespace DistanceBetweenCoordinates.Tests;

public class DistancesControllerTest
{
    [Fact]
    public async Task TestDistanceGenerationSuccessScenario()
    {
        // Arrange
        var firstCoordinate = new Coordinate
        {
            Latitude = 53.297975,
            Longitude = -6.372663
        };
        var secondCoordinate = new Coordinate
        {
            Latitude = 41.385101,
            Longitude = -81.440440
        };
        var expectedDistance = new DistanceDTO
        {
            Distance = 5536.338682266686
        };
        var mockLogger = new Mock<ILogger<DistancesController>>();
        var controller = new DistancesController(mockLogger.Object, new DistanceService());

        // Act
        var coordinates = new CoordinatesDTO
        {
            FirstCoordinate = firstCoordinate,
            SecondCoordinate = secondCoordinate
        };
        var result = await controller.CalculateDistance(coordinates);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedDistance.Distance, result.Distance);
    }
}