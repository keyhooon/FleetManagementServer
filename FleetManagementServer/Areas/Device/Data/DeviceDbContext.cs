using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Device.Data
{
    public class DeviceDbContext :DbContext
    {
        public DeviceDbContext(DbContextOptions<DeviceDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DeviceBuilder.OnModelCreating(modelBuilder);

        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<AvlPacket> AvlPackets { get; set; }
        public DbSet<DeviceParameterType> DeviceParameterTypes { get; set; }
        public DbSet<ParameterPacket> ParametersPackets { get; set; }
        public DbSet<ParameterPacketDetail> ParametersPacketDetails { get; set; }
        public DbSet<ParameterType> ParameterTypes { get; set; }
    }
}
