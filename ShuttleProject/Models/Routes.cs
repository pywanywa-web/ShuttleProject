using System.ComponentModel.DataAnnotations;

namespace ShuttleProject.Models
{
    public class Routes
    {
        [Key]
        public int RouteId { get; set; } 
        public string RouteName { get; set; }
        public string StartPoint { get; set; } 
        public string EndPoint { get; set; }
    }
}
