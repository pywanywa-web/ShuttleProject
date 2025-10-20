using System.ComponentModel.DataAnnotations;

namespace ShuttleProject.Models
{
    public class Passengers
    {
        [Key] 
        public int PassengerId { get; set; }    
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Type {  get; set; }   
    }
}
