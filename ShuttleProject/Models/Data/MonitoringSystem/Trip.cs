using System;
using System.Collections.Generic;

namespace ShuttleProject.Models.Data.MonitoringSystem;

public  class Trip
{
    public int TripId { get; set; }
  
    public string ShuttleId { get; set; } = null!;

    public int RouteId { get; set; }

    public TimeOnly? DepartutreTime { get; set; }

    public TimeOnly? ArrivalTime { get; set; }

    public string TripStatus { get; set; } = null!;

    public int PassengerId { get; set; }

    public virtual Passenger Passenger { get; set; } = null!;

    public virtual Route Route { get; set; } = null!;

    public virtual Shuttle Shuttle { get; set; } = null!;
}
