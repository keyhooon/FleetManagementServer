//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FleetManagementServer.Areas.Vehicle.Data
{
    using GeoAPI.Geometries;
    using NetTopologySuite.Geometries;
    using System;
    using System.Collections.Generic;
    
    public partial class FleetLocation
    {
        public int Id { get; set; }
        public int IdVehicle { get; set; }
        public Point Location { get; set; }
        public DateTime Date { get; set; }
    }
}