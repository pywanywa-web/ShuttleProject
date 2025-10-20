using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShuttleProject.Models
{
    public class Shuttles
    {
        [Key]
        public string ShuttleId { get; set; } 
        public string PlateNumber { get; set; } 
        public int Capacity { get; set; }   
        public string Status { get; set; }
        [ForeignKey("Driver")]  
        public int? DriverId { get; set; }


    }
}
