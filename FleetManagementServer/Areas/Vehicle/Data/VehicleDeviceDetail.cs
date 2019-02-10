using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Vehicle.Data
{
    public class VehicleDeviceDetail
    {
        public int Id { get; set; }
        public int vehicleDeviceId { get; set; }
        public int DeviceId { get; set; }

        public DateTime InstallTime { get; set; }

        public Device Device { get; set; }
    }
    public static class VehicleDeviceDetailBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDeviceDetail>(builder => { builder.HasData(VehicleDeviceDetailSeed.Seed()); });
        }
    }

    public static class VehicleDeviceDetailSeed
    {
        public static List<VehicleDeviceDetail> Seed()
        {
            return new List<VehicleDeviceDetail>() { new VehicleDeviceDetail() { }, new VehicleDeviceDetail() };
        }
    }
}
