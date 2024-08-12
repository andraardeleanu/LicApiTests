using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Models.Responses
{
    public class WorkpointResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Author { get; set; }
        public int CompanyId { get; set; }
    }
}
