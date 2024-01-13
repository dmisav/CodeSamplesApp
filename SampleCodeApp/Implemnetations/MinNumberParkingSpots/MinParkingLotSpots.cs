namespace SampleCodeApp.Implemnetations.MinNumberParkingSpots
{
    public static class MinParkingLotSpots
    {
        public static void Run()
        {
        
        }

        public static int CalculateMinParkingLotSpots(int[][] parkingStartEndTimes)
        {
            var parkinglotNumber = 0;
            var listOfLists = new List<List<int>>();
            int startHour = 0;
            int endHour = 0;
            for (int i =0 ; i < parkingStartEndTimes.Length; i++)
            {
                var lst = new List<int>();
                startHour = parkingStartEndTimes[i][0];
                endHour = parkingStartEndTimes[i][1];
                for (int j = startHour; j <= endHour; j++)
                {
                    lst.Add(j);
                }
                listOfLists.Add(lst);
            }

            var intersect = listOfLists.First();
            foreach (List<int> l in listOfLists)
            {
                intersect = intersect.Intersect(l).ToList();
                if (intersect.Any())
                {
                    parkinglotNumber++;
                }
            }

            return parkinglotNumber;
        }
    }
}

/*
 using System;
   using System.Collections.Generic;
   using System.Linq;
   
   public class Program
   {
   public static int MinParkingSpaces(int[][] parkingStartEndTimes)
   {
   // Sort the bookings by start time
   Array.Sort(parkingStartEndTimes, (a, b) => a[0].CompareTo(b[0]));
   
   // Priority queue to keep track of the end times of parking spaces currently in use
   SortedSet<int> endTimes = new SortedSet<int>();
   
   // Go through each booking and allocate parking spaces
   foreach (var booking in parkingStartEndTimes)
   {
   // Remove spaces that are free (where the end time is before the current booking's start time)
   endTimes.RemoveWhere(time => time <= booking[0]);
   
   // Allocate the current booking to a parking space
   endTimes.Add(booking[1]);
   }
   
   // The size of the endTimes set is the number of parking spaces needed
   return endTimes.Count;
   }
   
   public static void Main()
   {
   int[][] parkingTimes = new int[][]
   {
   new int[] { 5, 10 },
   new int[] { 0, 20 },
   new int[] { 25, 40 },
   new int[] { 35, 45 }
   };
   
   int result = MinParkingSpaces(parkingTimes);
   Console.WriteLine($"Minimum number of parking spaces required: {result}");
   }
   }
   
 */
 
 /*
  select movieid, round(avg(rating),1) as AverageRating from MovieRatings group by movieid order by AverageRating desc, movieid
    limit 10
 */