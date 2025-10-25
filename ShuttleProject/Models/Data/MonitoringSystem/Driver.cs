using System;
using System.Collections.Generic;

namespace ShuttleProject.Models.Data.MonitoringSystem;

public partial class Driver
{
    public int DriverId { get; set; }

    public string Name { get; set; } = null!;

    public string LicenseNo { get; set; } = null!;

    public int? Contact { get; set; }
    //public string ShuttleId { get;  set; }

    // Add this navigation property to fix CS1061
    public virtual ICollection<Shuttle> Shuttles { get; set; } = new List<Shuttle>();
}
