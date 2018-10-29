using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops
            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable trackable1 = null;
            ITrackable trackable2 = null;
            // Create a `double` variable to store the distance
            double distance = 0;
            
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            foreach (ITrackable location in locations )
            {
                double latitude = location.Location.Latitude;
                double longitude = location.Location.Longitude;
                GeoCoordinate LocA = new GeoCoordinate(latitude, longitude);
                foreach (ITrackable destination in locations)
                {
                    double destinationLat = destination.Location.Latitude;
                    double destinationLon = destination.Location.Longitude;
                    GeoCoordinate LocB = new GeoCoordinate(destinationLat,destinationLon);

                    if(LocB.GetDistanceTo(LocA) > distance)
                    {
                        distance = LocB.GetDistanceTo(LocA);
                        trackable1 = location;
                        trackable2 = destination;
                    }
                }


            }

            Console.WriteLine(trackable1.Name);
            Console.WriteLine(trackable2.Name);
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // Create a new Coordinate with your locB's lat and long
            
            
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
        }
    }
}