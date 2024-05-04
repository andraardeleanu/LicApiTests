using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Models.Requests
{
    public class AddWorkpointRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
    }
}
