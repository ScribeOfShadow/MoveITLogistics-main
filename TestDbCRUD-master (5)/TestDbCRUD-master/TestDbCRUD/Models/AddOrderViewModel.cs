using System.ComponentModel.DataAnnotations;
namespace TestDbCRUD.Models
{
    public class AddOrderViewModel
    {
        public string CompanyName { get; set; }
        public string Contents { get; set; }
        public int Quantity { get; set; }
        public string PickupLocation { get; set; }
        public string Destination { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ETA { get; set; }
        public string? PickupLocationID { get; set; }
        public string? DestinationID { get; set; }

    }
}
