using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Vehicle.Data
{
    public class VehicleDriver
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateTime AssignmentTime { get; set; }

        public Vehicle Vehicle { get; set; }
        public Driver Driver { get; set; }
    }
    public static class VehicleDriverBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDriver>(builder => { builder.HasData(VehicleDriverSeed.Seed()); });
        }
    }

    public static class VehicleDriverSeed
    {
        public static List<VehicleDriver> Seed()
        {
            return new List<VehicleDriver>() { new VehicleDriver() { }, new VehicleDriver() };
        }
    }

}
