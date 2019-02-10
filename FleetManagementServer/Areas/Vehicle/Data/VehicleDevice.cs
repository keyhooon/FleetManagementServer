using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Vehicle.Data
{
    public class VehicleDevice
    {
        public VehicleDevice()
        {
            Details = new HashSet<VehicleDeviceDetail>();
        }
        public int Id { get; set; }
        public int VehicleId { get; set; }

        public DateTime date { get; set; }

        public Vehicle Vehicle { get; set; }
        public ICollection<VehicleDeviceDetail> Details { get; set; }
    }
    public static class VehicleDeviceBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDevice>(builder => { builder.HasData(VehicleDeviceSeed.Seed()); });
        }
    }

    public static class VehicleDeviceSeed
    {
        public static List<VehicleDevice> Seed()
        {
            return new List<VehicleDevice>() { new VehicleDevice() { }, new VehicleDevice() };
        }
    }
}
