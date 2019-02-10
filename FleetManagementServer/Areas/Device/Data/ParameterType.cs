using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Device.Data
{
    public class ParameterType
    {
        public ParameterType()
        {
            DeviceParameterTypes = new HashSet<DeviceParameterType>();
            ParameterPacketDetails = new HashSet<ParameterPacketDetail>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }

        public ICollection<DeviceParameterType> DeviceParameterTypes { get; set; }
        public ICollection<ParameterPacketDetail> ParameterPacketDetails { get; set; }

    }

    public static class ParameterTypeBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParameterType>(builder => { builder.HasData(ParameterTypeSeed.Seed()); });
        }
    }

    public static class ParameterTypeSeed
    {

        public static List<ParameterType> Seed()
        {
            return new List<ParameterType>() { new ParameterType() { }, new ParameterType() };
        }
    }
}
