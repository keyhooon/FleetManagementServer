using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagementServer.Areas.Vehicle.Data;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Vehicle.Services.Vehicle
{
    public class VehicleService
    {
        private readonly FleetDbContext _fleetDbContext;

        public VehicleService( FleetDbContext fleetDbContext)
        {
            _fleetDbContext = fleetDbContext;
        }
        public async Task<List<Data.Vehicle>> GetVehicleListOnTripAsync()
        {
            return await _fleetDbContext.Vehicles.Include(Vehicle => Vehicle.Trips).Where((vehicle, i) => vehicle.Trips.Any(trip => trip.EndTime == null)).ToListAsync();
        }

        public async Task<List<Data.Vehicle>> GetVehicleListOntripAsync(int fleetWayId)
        {
            return await _fleetDbContext.Vehicles.Include(Vehicle => Vehicle.Trips).Where((vehicle, i) => vehicle.Trips.Any(trip => trip.EndTime == null && trip.FleetWay.Id == fleetWayId)).ToListAsync();
        }
        public async Task<IList<FleetWay>> GetFleetWaysListAsync()
        {
            return await GetFleetWaysListAsync();
        }
    }
}
