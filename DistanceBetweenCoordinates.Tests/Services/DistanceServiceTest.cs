using System.Threading.Tasks;
using DistanceBetweenCoordinates.DTOs;
using DistanceBetweenCoordinates.Models;
using DistanceBetweenCoordinates.Services;
using Xunit;
namespace DistanceBetweenCoordinates.Tests;

public class DistanceServiceTest
{
    [Fact]
    public async Task TestDistanceGeneration()
    {
        var distanceService = new DistanceService();
        // I used the provided coordinates as an example from the assessment
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

        // I used https://www.movable-type.co.uk/scripts/latlong.html to calculate the distance and used this as a reference
        var expectedDistance = new DistanceDTO
        {
            Distance = 5536.338682266686
        };

        var actualDistance = await distanceService.CalculateDistanceBetweenTwoCoordinates(firstCoordinate, secondCoordinate);
        Assert.Equal(expectedDistance.Distance, actualDistance.Distance);
    }
}