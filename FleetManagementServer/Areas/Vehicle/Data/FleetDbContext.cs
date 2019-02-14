using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Vehicle.Data
{
    public class FleetDbContext : DbContext
    {
        public FleetDbContext(DbContextOptions<FleetDbContext> options)
                    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            VehicleBrandBuilder.OnModelCreating(modelBuilder);
            VehicleTypeBuilder.OnModelCreating(modelBuilder);
            FleetWayBuilder.OnModelCreating(modelBuilder);

        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<FleetLocation> FleetLocations { get; set; }
        public DbSet<FleetWay> FleetWays { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Vehicle> Vehicles{ get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleDevice> VehicleDevices { get; set; }
        public DbSet<VehicleDeviceDetail> VehicleDeviceDetails { get; set; }
        public DbSet<VehicleDriver> VehicleDrivers { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }


    }
}
