using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagementServer.Areas.Vehicle.Data;

namespace FleetManagementServer.Areas.Vehicle.Services.Trip
{
    public class TripService
    {
        private readonly FleetDbContext _fleetDbContext;

        public TripService(FleetDbContext fleetDbContext)
        {
            _fleetDbContext = fleetDbContext;
        }

        public bool IsOnTrip(Data.Vehicle vehicle)
        {
            return _fleetDbContext.Trips.Where((trip, i) => trip.VehicleId == vehicle.Id).TakeLast(1).Any(trip => trip.EndTime != null);
        }

        public Data.Trip GetCurrentTrip(Data.Vehicle vehicle)
        {
            return _fleetDbContext.Trips.Where((t, i) => t.VehicleId == vehicle.Id && t.EndTime != null).TakeLast(1).FirstOrDefault();
        }

        public List<Data.Trip> GetAliveTrips()
        {
            return _fleetDbContext.Trips.Where((trip, i) => trip.EndTime == null).ToList();
        }
    }
}
