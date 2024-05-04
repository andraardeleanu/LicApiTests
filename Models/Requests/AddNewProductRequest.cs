using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Models.Requests
{
    public class AddNewProductRequest
    {
        public string Name{ get; set; }
        public decimal Price { get; set; }
        public int AvailableStock { get; set; }
    }
}
