namespace LicApiTests.Models.Responses
{
    public class BillResponse
    {
        public string OrderNo { get; set; }
        public string Customer { get; set; }
        public string WorkpointName { get; set; }
        public string CompanyName { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public List <BillDetailsProducts> OrderProducts{ get; set;}
}
}
