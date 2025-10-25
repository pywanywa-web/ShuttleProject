using System;
using System.Collections.Generic;

namespace ShuttleProject.Models.Data.MonitoringSystem;

public  class Passenger
{
    public int PassengerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
    //public int Id { get;  set; }
}
