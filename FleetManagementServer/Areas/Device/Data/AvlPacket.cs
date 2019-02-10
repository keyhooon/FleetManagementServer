using System;

namespace FleetManagementServer.Areas.Device.Data
{
    public class AvlPacket
    {
        public int Id { get; set; }
        public int ParameterPacketId { get; set; }
        public double? GpsLatitiude { get; set; }
        public double?          GpsLongitude { get; set; }
        public double?          GpsAltitude  { get; set; }
        public double?          GpsAngle     { get; set; }
        public int?             Satellites   { get; set; }
        public double?          Speed        { get; set; }
        public int?             EventIoId    { get; set; }
        public bool?            IsValid      { get; set; }
        public DateTime? ServerTime   { get; set; }

        public ParameterPacket ParameterPacket { get; set; }
    }
}
