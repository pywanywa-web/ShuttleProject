using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShuttleProject.Models
{
    public class Routes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RouteId { get; set; } 
        public string RouteName { get; set; }
        public string StartPoint { get; set; } 
        public string EndPoint { get; set; }
    }
}
