using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Device.Data
{
    public class ParameterPacket
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public DateTime DateTime { get; set; }

        public AvlPacket AvlPacket { get; set; }
        public ICollection<ParameterPacketDetail> ParameterPacketDetails { get; set; }
        public Device Device { get; set; }
    }

    public static class ParameterPacketBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceParameterType>(builder => { builder.HasData(ParameterPacketSeed.Seed()); });
        }
    }

    public static class ParameterPacketSeed
    {

        public static List<ParameterPacket> Seed()
        {
            return new List<ParameterPacket>() { new ParameterPacket() { }, new ParameterPacket() };
        }
    }
}
