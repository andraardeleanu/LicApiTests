using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicApiTests.Mappers
{
    public class ApiResponseMapper
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string ValidationMessage { get; set; }
    }
}
