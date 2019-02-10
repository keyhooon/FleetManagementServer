using System.Collections.Generic;
using System.IO;
using System.Linq;
using FleetManagementServer.Areas.Vehicle.Data;
using GeoAPI.Geometries;
using SharpKml.Dom;
using SharpKml.Engine;

namespace FleetManagementServer.Areas.Vehicle.Services
{
    public static class FleetWayHelper
    {
        public static IList<FleetWay> GetFleetWaysFromKml(Stream kmlStream)
        {
            var file = KmlFile.Load(kmlStream);
            var fleetWays = new List<FleetWay>();
            if (!(file.Root is Kml kml)) return fleetWays;
            foreach (var way in kml.Feature.Children.OfType<Placemark>().Where(placemark => placemark.Geometry.GetType()==typeof(LineString)).ToList())
            {
                    fleetWays.Add(new FleetWay()
                    {
                        Name = way.Name,
                        Way  = new NetTopologySuite.Geometries.LineString(((LineString) way.Geometry).Coordinates.Select(vector => new Coordinate(vector.Latitude, vector.Longitude)).ToArray())
                    });
            }
            return fleetWays;
        }
    }
}
