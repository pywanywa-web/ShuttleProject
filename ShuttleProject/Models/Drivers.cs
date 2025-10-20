using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace ShuttleProject.Models
{
    public class Drivers
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverId { get; set; }
       
        public string Name { get; set; }
        
        public string LicenseNo { get; set; }
        
        public int Contact { get; set; }  
    }
}
