using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Device.Data
{
    public class DeviceParameterType
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int ParameterTypeId { get; set; }

        public Device Device { get; set; }
        public ParameterType ParameterType { get; set; }
        
    }
    public static class DeviceParameterTypeBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceParameterType>(builder => { builder.HasData(DeviceParameterTypeSeed.Seed()); });
        }
    }

    public static class DeviceParameterTypeSeed
    {

        public static List<DeviceParameterType> Seed()
        {
            return new List<DeviceParameterType>() { new DeviceParameterType() { }, new DeviceParameterType() };
        }
    }
}
