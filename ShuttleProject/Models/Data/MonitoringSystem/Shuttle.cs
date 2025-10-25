using System;
using System.Collections.Generic;

namespace ShuttleProject.Models.Data.MonitoringSystem;

public partial class Shuttle
{
    public string ShuttleId { get; set; } = null!;

    public string PlateNumber { get; set; } = null!;

    public int Capacity { get; set; }

    public string Status { get; set; } = null!;

    public int DriverId { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
   // public string? Name { get;  set; }
    //public int Id { get;  set; }
}
