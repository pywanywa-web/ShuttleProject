using System;
using System.Collections.Generic;

namespace ShuttleProject.Models.Data.MonitoringSystem;

public partial class Route
{
    public int RouteId { get; set; }

    public string RouteName { get; set; } = null!;

    public string? StartPoint { get; set; }

    public string? EndPoint { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
    //public int Id { get;  set; }
    //public string? Name { get;  set; }
}
