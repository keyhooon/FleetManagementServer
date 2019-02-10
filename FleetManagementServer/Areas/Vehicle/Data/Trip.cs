using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Vehicle.Data
{
    public class Trip
    {
        public int Id { get; set; }
        public int FleetWayId { get; set; }
        public int VehicleId { get; set; }

        public FleetWay FleetWay { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
    public static class TripBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>(builder => { builder.HasData(TripSeed.Seed()); });
        }
    }

    public static class TripSeed
    {
        public static List<Trip> Seed()
        {
            return new List<Trip>() { new Trip() { Id = 1, StartTime = DateTime.Parse("2015/5/7"),}, new Trip() };
        }
    }
}
