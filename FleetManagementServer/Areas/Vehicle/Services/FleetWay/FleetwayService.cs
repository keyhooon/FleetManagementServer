using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FleetManagementServer.Areas.Vehicle.Data;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Vehicle.Services
{
    public class FleetwayService
    {
        private readonly FleetDbContext _fleetDbContext;

        public FleetwayService(FleetDbContext fleetDbContext)
        {
            _fleetDbContext = fleetDbContext;

        }

        public async Task<List<FleetWay>> GetFleetWaysListAsync(Expression<Func<FleetWay, bool>> condition)
        {
            return await _fleetDbContext.FleetWays.Where(condition).Include(way => way.Trips).ThenInclude(trip => trip.Vehicle).ToListAsync();
        }
        public async Task<IList<FleetWay>> GetFleetWaysListAsync()
        {
            return await GetFleetWaysListAsync(way => true);
        }


    }
}
