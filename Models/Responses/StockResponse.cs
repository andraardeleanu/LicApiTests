using System.Security.Policy;

namespace LicApiTests.Models.Responses
{
    public class StockResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int AvailableStock { get; set; }
        public int PendingStock { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
