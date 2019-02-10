using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagementServer.Areas.Vehicle.Services.Trip
{
    public static class TripExtensions
    {
        public static bool IsEnded(this Data.Trip trip)
        {
            return trip.EndTime != null;
        }
    }
}
