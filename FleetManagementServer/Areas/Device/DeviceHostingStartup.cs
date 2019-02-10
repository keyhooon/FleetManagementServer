using FleetManagementServer.Areas.Device;
using FleetManagementServer.Areas.Device.Data;
using FleetManagementServer.Areas.Vehicle.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DeviceHostingStartup))]
namespace FleetManagementServer.Areas.Device
{
    public class DeviceHostingStartup : IHostingStartup
    {

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DeviceDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DeviceDbContextConnection")));
            });
        }
    }
}