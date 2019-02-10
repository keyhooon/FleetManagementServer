using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Device.Data
{
    public class Device
    {
        public Device()
        {
            DeviceParameterTypes = new HashSet<DeviceParameterType>();
            ParameterPackets = new HashSet<ParameterPacket>();
        }
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Imei { get; set; }
        public byte[] SecurityCode { get; set; }
        public bool SecurityCodeVerification { get; set; }
        public ICollection<DeviceParameterType> DeviceParameterTypes { get; set; }
        public ICollection<ParameterPacket> ParameterPackets { get; set; }
    }
    public static class DeviceBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(builder => { builder.HasData(DeviceSeed.Seed()); });
        }
    }

    public static class DeviceSeed
    {
        public static Guid Device1_Guid = Guid.Parse("ECCB0560-AF46-4CEA-A4EF-84A6A132BF75");
        public static Guid Device2_Guid = Guid.Parse("F9EA6A69-914F-4868-A838-BFDEF19743C5");
        public static List<Device> Seed()
        {
            return new List<Device>() { new Device() {Id = 2, Guid = Device1_Guid, Imei = "990000862471854",SecurityCode = new byte[]{1,2,3,4,5,6,7,8},SecurityCodeVerification = true},
                                        new Device() {Id = 1, Guid = Device1_Guid, Imei = "351756051523999",SecurityCode = new byte[]{1,2,3,4,5,6,7,8},SecurityCodeVerification = true}};
        }
    }
}
