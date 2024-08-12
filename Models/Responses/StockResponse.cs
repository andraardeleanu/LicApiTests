namespace LicApiTests.Models.Responses
{
    public class StockResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int AvailableStock { get; set; }
        public int PendingStock { get; set; }
    }
}
