using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Device.Data
{
    public class ParameterPacketDetail
    {
        public int Id { get; set; }
        public int ParameterPacketId { get; set; }
        public int DeviceParameterTypeId { get; set; }
        public int Value { get; set; }

        public ParameterPacket ParameterPacket { get; set; }
        public ParameterType ParameterType { get; set; }

    }

    public static class ParameterPacketDetailBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParameterPacketDetail>(builder => { builder.HasData(ParameterPacketDetailSeed.Seed()); });
        }
    }

    public static class ParameterPacketDetailSeed
    {

        public static List<ParameterPacketDetail> Seed()
        {
            return new List<ParameterPacketDetail>() { new ParameterPacketDetail() { }, new ParameterPacketDetail() };
        }
    }
}
