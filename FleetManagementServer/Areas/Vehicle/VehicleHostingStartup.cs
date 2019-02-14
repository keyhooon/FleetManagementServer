using FleetManagementServer.Areas.Vehicle.Data;
using FleetManagementServer.Areas.Vehicle.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FleetManagementServer.Areas.Vehicle.VehicleHostingStartup))]
namespace FleetManagementServer.Areas.Vehicle
{
    public class VehicleHostingStartup : IHostingStartup
    {

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FleetDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("VehicleDbContextConnection"),optionsBuilder => optionsBuilder.UseNetTopologySuite()).EnableSensitiveDataLogging());
                services.AddFleetWayService();
            });
        }
    }
}