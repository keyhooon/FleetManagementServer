//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.IO;
using FleetManagementServer.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementServer.Areas.Vehicle.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleType()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
    public static class VehicleTypeBuilder
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleType>(builder => { builder.HasData(VehicleTypeSeed.Seed()); });
        }
    }

    public static class VehicleTypeSeed
    {
        public static IEnumerable<VehicleType> Seed()
        {
            var ImageFolderPath = $"{Directory.GetCurrentDirectory()}\\Areas\\Vehicle\\Resources\\VehicleTypeImage\\";
            return new VehicleType[] {
                new VehicleType() {Id = 1, Name = "Truck", Image = ImageHelper.FromFileToByte($"{ImageFolderPath}truck.png") },
                new VehicleType() {Id = 2, Name = "bus", Image = ImageHelper.FromFileToByte($"{ImageFolderPath}bus.png") },
                new VehicleType() {Id = 3, Name = "car", Image = ImageHelper.FromFileToByte($"{ImageFolderPath}car.png") }};
        }
}
}
