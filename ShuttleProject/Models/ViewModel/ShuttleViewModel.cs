namespace ShuttleProject.Models.ViewModel
{
    public class ShuttleViewModel
    {
        public string ShuttleId { get; set; } = null!;

        public string PlateNumber { get; set; } = null!;

        public int Capacity { get; set; }

        public string Status { get; set; } = null!;

        public int DriverId { get; set; }

    }
}
