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
            return new List<VehicleDevice>()
            {
                new VehicleDevice() {Id = 1,date = DateTime.Parse("2017/1/1"),VehicleId = 1}
              , new VehicleDevice() { Id = 2, date = DateTime.Parse("2018/1/1"), VehicleId = 2 }
              , new VehicleDevice() { Id = 3, date = DateTime.Parse("2017/5/1"), VehicleId = 5 }
              , new VehicleDevice() { Id = 4, date = DateTime.Parse("2018/1/1"), VehicleId = 4 }
              , new VehicleDevice() { Id = 5, date = DateTime.Parse("2018/1/1"), VehicleId = 3 }
            };
        }
    }
}
