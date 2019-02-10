using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FleetManagementServer.Areas.Vehicle.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;

namespace FleetManagementServer.Areas.Vehicle.Services
{
    public static class FleetWayExtensions
    {
        public static void ExportFleetWaysToKml(this IEnumerable<FleetWay> fleetWays, Stream kmlStream)
        {
            var kml = new Kml();
            foreach (var fleetWay in fleetWays)
            {
                kml.Feature.AddChild(new Placemark
                {
                    Name     = fleetWay.Name,
                    Geometry = new LineString { Coordinates = new CoordinateCollection(fleetWay.Way.Coordinates.Select(coordinate => new Vector(coordinate.X, coordinate.Y))) },
                });
            }
            KmlFile.Create(kml, true).Save(kmlStream);
        }
    }

    public static class FleetWaySeviceExtensions
    {
        public static IServiceCollection AddFleetWayService(this IServiceCollection service)
        {
            return service.AddSingleton<FleetwayService>();
        }
    }
}
