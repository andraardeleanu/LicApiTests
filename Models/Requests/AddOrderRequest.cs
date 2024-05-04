namespace LicApiTests.Models.Requests
{
    public class AddOrderRequest
    {
        public string OrderNo { get; set; }
        public string Author { get; set; }
        public string CreatedBy { get; set; }
        public int WorkpointId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductWithQuantity> Products { get; set; }
    }
}
