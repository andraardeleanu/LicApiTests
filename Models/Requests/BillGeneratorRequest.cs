namespace LicApiTests.Models.Requests
{
    public class BillGeneratorRequest
    {
        public string CreatedBy { get; set; }
        public string OrderNo { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string WorkpointName { get; set; }
        public string CompanyName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
