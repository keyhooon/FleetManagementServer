using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagementServer.Areas.Device.Data
{
    public class DeviceType
    {
        public DeviceType()
        {
            Devices = new HashSet<Device>();
            DeviceParameterTypes = new HashSet<DeviceParameterType>();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public ICollection<Device> Devices { get; set; }
        public ICollection<DeviceParameterType> DeviceParameterTypes { get; set; }
    }
}
