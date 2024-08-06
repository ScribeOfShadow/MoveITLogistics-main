namespace TestDbCRUD.Models
{
    public class UpdateOrderViewModel
    {

        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Contents { get; set; }
        public int Quantity { get; set; }
        public string PickupLocation { get; set; }
        public string Destination { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ETA { get; set; }

        public Boolean UserStatus { get; set; }

    }
}
