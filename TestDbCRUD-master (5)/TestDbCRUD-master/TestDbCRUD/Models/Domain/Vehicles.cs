using System.ComponentModel.DataAnnotations;
namespace TestDbCRUD.Models.Domain
{
    public class Vehicles
    {
        [Key]
        public int VehicleId { get; set; }


        public string VehicleType { get; set; }
        public string status { get; set; }
        public string VehicleLocation { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
    }
}
