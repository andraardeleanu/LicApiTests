using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Dtos
{
    public class OrderMapper
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Author { get; set; }
        public int WorkpointId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
    }
}
