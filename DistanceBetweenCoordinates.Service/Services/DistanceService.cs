using System;
using DistanceBetweenCoordinates.DTOs;
using DistanceBetweenCoordinates.Models;

namespace DistanceBetweenCoordinates.Services;

public class DistanceService
{
    private const double EarthRadiusInKilometers = 6371;
    public Task<DistanceDTO> CalculateDistanceBetweenTwoCoordinates(Coordinate firstCoordinate, Coordinate secondCoordinate)
    {
        var distance = new DistanceDTO();
        var lon1 = toRadians(firstCoordinate.Longitude);
        var lon2 = toRadians(secondCoordinate.Longitude);
        var lat1 = toRadians(firstCoordinate.Latitude);
        var lat2 = toRadians(secondCoordinate.Latitude);

        // Haversine formula
        double dlon = lon2 - lon1;
        double dlat = lat2 - lat1;
        double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Pow(Math.Sin(dlon / 2), 2);

        double c = 2 * Math.Asin(Math.Sqrt(a));

        // calculate the result
        distance.Distance = c * EarthRadiusInKilometers;
        return Task.FromResult(distance);
    }
    private double toRadians(
           double angleIn10thofaDegree)
    {
        // Angle in 10th of a degree
        return (angleIn10thofaDegree * Math.PI) / 180;
    }
}
