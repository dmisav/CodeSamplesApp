using SampleCodeApp.Implemnetations.MinNumberParkingSpots;

namespace SampleCodeApp.Tests;

[TestFixture]
public class MinParkingLotSpotsTests
{
    [Test]
    public void ShouldCalculateMinParkingSpots()
    {
        int[][] inputData = { new int[] { 1, 2}, new int[] { 2, 5}, new int[] { 3, 8}, new int[] { 8, 11} };
        
       var res= MinParkingLotSpots.CalculateMinParkingLotSpots(inputData);
       Assert.AreEqual(2, res);
    }
}